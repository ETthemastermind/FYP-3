using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;

public class DioramaEnterGesture : MonoBehaviour
{
    public GameObject DioramaDisplay;
    public GameObject DioramaStand;
    public bool InArea;

    public GameObject RightPalm;  
    public GameObject LeftPalm;
    public LineRenderer LR;
    public float PalmDistance;
    public float MaxHandDistance;
    public float Timer;
    public float ElapsedTime;
    public Material Red;
    public Material Orange;
    public Material Green;

    public bool GestureActive = false;

    public GameObject SOSR;

    public GameObject SOSRObject;
    public int LevelToLoad;

    //public GameObject DebugSphere;

    public Animator animator;

    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>(); //gets the line renderer component

        actions.Add("Enter", OnFadeComplete);
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    // Update is called once per frame
    void Update()
    {
        PalmDistance = Vector3.Distance(RightPalm.transform.position, LeftPalm.transform.position); // Finds the distance between left and right palm
        


        if (InArea == true)
        {

            if (GestureActive == true) // if diorma hand gesture is true
            {
                LR.enabled = true; //turn on line renderer 
                LR.SetPosition(0, RightPalm.transform.position); //set positions 1 and 2 of the line renderer to the palms.
                LR.SetPosition(1, LeftPalm.transform.position);

                if (PalmDistance >= 0 && PalmDistance <= (MaxHandDistance / 3))
                {

                    LR.material = Red; //When hands get put together, should be red. acts as a sort of loading bar.
                    ElapsedTime = 0f;
                    //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

                }
                else if (PalmDistance >= (MaxHandDistance / 3) && (PalmDistance <= (MaxHandDistance / 3) * 2))
                {

                    LR.material = Orange;
                    ElapsedTime = 0f;
                    //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

                }
                else if (PalmDistance >= MaxHandDistance)
                {
                    Debug.Log("Max Distance Reached");
                    LR.material = Green;

                    if (ElapsedTime <= Timer) //hold the green position for a few seconds
                    {
                        ElapsedTime += Time.deltaTime;

                    }
                    else if (ElapsedTime >= Timer)
                    {
                        //DebugSphere.GetComponent<Renderer>().material.color = Color.red;
                        FadeToLevel(2);
                    }

                }

            }
            else { }

            if (GestureActive == false) //turns off the line renderer when gesture is inactive
            {
                LR.enabled = false;

            }

        }
       
        
    }

    public void DioramaGestureActive() //using detectors on the gesture controller, this activates when both hands are facing forwards with open palms 
    {

        if (PalmDistance <= 0.5f) //if the the user's hands are close together, activates this bool to enable the rest of the script to work 
        {
            GestureActive = true;

        }
        

    }

    public void DioramaGestureInactive()
    {
        GestureActive = false;
        //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

    }

    public void FadeToLevel(int LevelIndex)
    {
        //animator.SetTrigger("FadeOut");
        OnFadeComplete();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
        //LevelToLoad = 0;
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Twat");
        InArea = true;
        if (other.gameObject.tag == "InteractRing" && other.gameObject.transform.parent.tag == "DioramaDisplay")
        {
            DioramaDisplay = other.gameObject.transform.parent.gameObject;
            for (int i = 0; i < DioramaDisplay.transform.childCount; i++)
            {
                if (DioramaDisplay.transform.GetChild(i).gameObject.tag == "Artefact")
                {
                    DioramaStand = DioramaDisplay.transform.GetChild(i).gameObject;
                    LevelToLoad = DioramaStand.GetComponent<Diorama_Teleport>().TargetSceneIndex; //get the scene index from the display stand

                }

            }
        }

        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        InArea = false;
        DioramaDisplay = null;
        DioramaStand = null;
        LevelToLoad = 0;
    }

}
