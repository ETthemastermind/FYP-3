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

    public bool UsingVR_Hands = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
        //GuideBook.transform.parent = Palm.transform;
        //GuideBook.transform.localPosition = new Vector3(0.2f, -0.05f, 0f);
        GuideBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingVR_Hands == true)
        {
            if (SteamVR_Actions._default.Y_Button.GetState(SteamVR_Input_Sources.LeftHand) == true)
            {
                Active();
                

            }

            else if (SteamVR_Actions._default.Y_Button.GetState(SteamVR_Input_Sources.LeftHand) == false)
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

        


    }

    public void Active()
    {
        if (ActiveGesture == false)
        {
            GuideBook.GetComponent<NotebookTelemetrySystem>().PushData("Guidebook Opened");
            Debug.Log("Active Gesture: Spawn Guidebook");
            GuideBook.SetActive(true);
            ActiveGesture = true;
        }
        
        


    }

    public void Inactive()
    {

        if (ActiveGesture == true)
        {
            GuideBook.GetComponent<NotebookTelemetrySystem>().PushData("Guidebook Closed");
            ActiveGesture = false;
            Debug.Log("Inactive Gesture: Spawn Guidebook");
            GuideBook.SetActive(false);
        }
        
        



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
