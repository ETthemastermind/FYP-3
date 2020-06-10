using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class SpawnGuideBook : MonoBehaviour
{

    public GameObject GuideBook;
    public GameObject Palm;
    public GameObject VR_LeftHand;
    public GameObject PlayerController;

    private bool ActiveGesture = false;
    public Vector3 Position_Offset;
    public Vector3 RotationOffset;

    
    // Start is called before the first frame update
    void Start()
    {
        
        GuideBook.transform.parent = Palm.transform;
        GuideBook.transform.localPosition = new Vector3(0.2f, -0.05f, 0f);
        GuideBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.LeftTriggerTouch.GetState(SteamVR_Input_Sources.LeftHand) == false && SteamVR_Actions._default.LeftGripTouch.GetState(SteamVR_Input_Sources.LeftHand) == false && SteamVR_Actions._default.X_Button_Touch.GetState(SteamVR_Input_Sources.LeftHand) == false)
        {
            Active();

        }

        else
        {
            Inactive();
        }
        /*
        if (VR_LeftHand.transform.rotation.z > 0.5f && VR_LeftHand.transform.rotation.z < 0.8f)
        {
            Active();

        }

        else
        {
            Inactive();

        }

        */

    }

    public void Active()
    {
        ActiveGesture = true;
        Debug.Log("Active Gesture: Spawn Guidebook");
        GuideBook.SetActive(true);
        


    }

    public void Inactive()
    {
        ActiveGesture = false;
        Debug.Log("Inactive Gesture: Spawn Guidebook");
        GuideBook.SetActive(false);
        



    }

    public void PalmUpTrue()
    {
        Debug.Log("Palm Facing Up");
    }

    public void PalmUpFalse()
    {
        Debug.Log("Palm Not Facing Up");
    }

    public void HandOpenTrue()
    {
        Debug.Log("hand Open");
    }

    public void HandOpenFalse()
    {
        Debug.Log("Hand Closed");
    }
}
