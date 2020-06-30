using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class TeleportV2 : MonoBehaviour
{
    public GameObject Player;
    public LineRenderer LR;
    public bool _IsPointing;
    public bool Teleport;

    public GameObject FingerTip;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public GameObject CurrentHitObject;
    public GameObject LastObjectHit;
    private float CurrentHitDistance;

    public Vector3[] ArcPos;

    public AudioSource AS;
    public AudioClip TeleportNoise;
    

    public GameObject Cursor;
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
        LR = gameObject.GetComponent<LineRenderer>();
        LR.enabled = false;
        actions.Add("Teleport", TeleportPlayer);



        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }
        

    // Update is called once per frame
    void Update()
    {
        //TeleportTestCursor.transform.position += (TeleportTestCursor.transform.forward * 5f) * Time.deltaTime;
        
        Debug.Log("Test");

        RaycastHit ObjectHit;

        if (Physics.SphereCast(FingerTip.transform.position, sphereRadius, FingerTip.transform.forward, out ObjectHit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
        {

            Debug.Log("Left Hand SC_Hit:" + ObjectHit.transform.name);
            if (ObjectHit.transform.tag == "LM_TP_Area")
            {
                LR.enabled = true;
                ArcPos[0] = FingerTip.transform.position;
                ArcPos[2] = ObjectHit.point ;
                Vector3 Midpoint = (ArcPos[0] + ArcPos[2]) / 2;
                float Midpoint_Y = (ArcPos[0].y + Midpoint.y) / 2;
                Midpoint = new Vector3(Midpoint.x, Midpoint_Y, Midpoint.z);




                LR.SetPosition(0, ArcPos[0]);
                LR.SetPosition(1, Midpoint);
                LR.SetPosition(2, ArcPos[2]);





                Cursor.transform.position = ObjectHit.point;


                if (Teleport == true)
                {
                    Vector3 NewPlayerLocation = new Vector3(Cursor.transform.position.x, Player.transform.parent.transform.position.y, Cursor.transform.position.z);
                    Player.transform.parent.position = NewPlayerLocation;
                    Teleport = false;
                }

            }






        }


        LastObjectHit = CurrentHitObject;
        if (_IsPointing == true)
        {
            

        }

        
    }


    public void IsPointing()
    {
        Debug.Log("Player started pointing _LMTP");
        _IsPointing = true;
        Cursor.SetActive(true);
        


    }

    public void IsNotPointing()
    {
        Debug.Log("Player stopped pointing_LMTP");
        _IsPointing = false;
        LR.enabled = false;
        Cursor.SetActive(false);

    }



    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(FingerTip.transform.position, FingerTip.transform.position + FingerTip.transform.forward * 50);
        Gizmos.DrawWireSphere(FingerTip.transform.position + FingerTip.transform.forward * CurrentHitDistance, sphereRadius);
    }



    public void TeleportPlayer()
    {
        Teleport = true;
        
    }
}