using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OH_GripArtefact : MonoBehaviour
{
    public bool Gripping;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true)
        {
            Debug.Log("Gripping");
            Gripping = true;

        }

        else
        {
            Gripping = false;

        }
    }
}
