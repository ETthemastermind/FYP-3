using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;


public class debug : MonoBehaviour
{
    public GameObject Parent;
    
    public GameObject Artifact;

    
    // Start is called before the first frame update
    void Start()
    {
       



        
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<TMPro.TextMeshProUGUI>().text = Parent.gameObject.name + "\n" + Artifact.gameObject + "\n" + Artifact.GetComponent<PickUpObject_Hand>().PickUpController;


        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true) //picking up
        {
            Debug.Log("Hand Closed");

        }


        else if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == false)
        {
            Debug.Log("Hand Pointing");
        }

        else
        {
            

        }
    }
}
