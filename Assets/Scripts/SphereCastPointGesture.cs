using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;

public class SphereCastPointGesture : MonoBehaviour
{
    public bool _IsPointing = false;

    public GameObject RightFingerTip;
    public GameObject LeftFingerTip;
    public GameObject FingerTip;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public GameObject CurrentHitObject;
    public GameObject LastHitObject;
    private float CurrentHitDistance;

    public GameObject KeywordObject;
    public bool KeywordSelected = false;

    public LineRenderer LR;

    public GameObject Player;
    public AudioSource AS;
    public AudioClip SelectSound;

    public bool LeapHandsActive = false;

    
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        LR.enabled = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsPointing == true)
        {
            
            RaycastHit ObjectHit;
            
            

            if (Physics.SphereCast(FingerTip.transform.position, sphereRadius, FingerTip.transform.forward, out ObjectHit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
            {
                CurrentHitObject = ObjectHit.transform.gameObject;
                CurrentHitDistance = ObjectHit.distance;
                
                Debug.Log(ObjectHit);
                if (CurrentHitObject.gameObject.tag == "Keyword")
                {
                    LR.enabled = true;
                    LR.SetPosition(0, FingerTip.transform.position);
                    LR.SetPosition(1, ObjectHit.point);
                    if (KeywordObject != null)
                    {
                        KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                    }
                    
                    KeywordObject = CurrentHitObject.transform.gameObject;
                    KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
                    

                    if (CurrentHitObject != LastHitObject)
                    {
                        AS.PlayOneShot(SelectSound);
                    }

                    LastHitObject = CurrentHitObject;
                }

                else
                {
                    LR.SetPosition(1, FingerTip.transform.position);
                }
            }
            else
            {
                CurrentHitDistance = maxDistance;
                
                
            }

        }

        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == false && LeapHandsActive == false) //&& SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
        {
            _IsPointing = true;
            FingerTip = RightFingerTip;
            
        }
        else if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.LeftHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.LeftHand) == false && LeapHandsActive == false) //&& SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
        {
            _IsPointing = true;
            FingerTip = LeftFingerTip;
            
        }

        else if (LeapHandsActive == false)
        {
            _IsPointing = false;
            LR.enabled = false;
            FingerTip = RightFingerTip;
        }

        else
        {
            _IsPointing = false;
            LR.SetPosition(0, FingerTip.transform.position);
            LR.SetPosition(1, FingerTip.transform.position);

            LR.enabled = false;
            FingerTip = RightFingerTip;


        }
        
        

    }

    public void IsPointing()
    {
        Debug.Log("Player started pointing");
        _IsPointing = true;
        LR.enabled = true;
    }

    public void IsNotPointing()
    {
        Debug.Log("Player stopped pointing");
        _IsPointing = false;
        LR.enabled = false;
        KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(FingerTip.transform.position, FingerTip.transform.position + FingerTip.transform.forward * CurrentHitDistance);
        Gizmos.DrawWireSphere(FingerTip.transform.position + FingerTip.transform.forward * CurrentHitDistance, sphereRadius);
    }
}
