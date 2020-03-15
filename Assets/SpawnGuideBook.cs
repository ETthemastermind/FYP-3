using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuideBook : MonoBehaviour
{

    public GameObject GuideBook;
    public GameObject Palm;
    public GameObject PlayerController;

    private bool ActiveGesture;
    public Vector3 Position_Offset;
    public Vector3 RotationOffset;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveGesture == true)
        {
            

            
        }

        if (ActiveGesture == false)
        {
            

        }
        
    }

    public void Active()
    {
        ActiveGesture = true;
        Debug.Log("Active Gesture: Spawn Guidebook");


    }

    public void Inactive()
    {
        ActiveGesture = false;
        Debug.Log("Inactive Gesture: Spawn Guidebook");
       
        

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
