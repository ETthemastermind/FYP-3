using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;

public class SphereCastPointGesture : MonoBehaviour
{
    public bool _IsPointing = false;

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
            LR.SetPosition(0,FingerTip.transform.position);
            
            if (Physics.SphereCast(FingerTip.transform.position, sphereRadius, FingerTip.transform.forward, out ObjectHit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
            {
                CurrentHitObject = ObjectHit.transform.gameObject;
                CurrentHitDistance = ObjectHit.distance;
                LR.SetPosition(1, ObjectHit.point);
                Debug.Log(ObjectHit);
                if (CurrentHitObject.gameObject.tag == "Keyword")
                {
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
                    
                }
            }
            else
            {
                CurrentHitDistance = maxDistance;
                CurrentHitObject = null;
                
                
            }

        }
        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == false)
        {
            _IsPointing = true;
            LR.enabled = true;
        }

        else
        {
            _IsPointing = false;
            LR.enabled = false;
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
