using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Debuging : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.LeftTriggerTouch.GetState(SteamVR_Input_Sources.LeftHand) == false && SteamVR_Actions._default.LeftGripTouch.GetState(SteamVR_Input_Sources.LeftHand) == false && SteamVR_Actions._default.X_Button_Touch.GetState(SteamVR_Input_Sources.LeftHand) == false)
        {
            Debug.Log("User not touching buttons");
        }
        else
        {
            Debug.Log("User touching buttons");
        }
    }
}
