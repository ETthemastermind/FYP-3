using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

public class Artefact_Hand_PickUp : MonoBehaviour //
{


    public GameObject DebugCube;
    public GameObject ObjectToPickUp; //object to pick up, gotten from PickUpObject_Hand script
    public Vector3 ArtefactObject_StartLocation; //reference for the location the artefact starts at
    public Vector3 ArtefactObject_StartOrientation; //reference for the rotation the artefact starts at
    public GameObject ArtefactObject_Home; //refeernce for the home display of the object
    public GameObject Palm; // reference the leap motion palm, right hand

    public GameObject Vr_RightHand;
    public bool VR_HoldingObject;
    public bool Gripping;

    public GameObject Player;
    public AudioSource AS;
    public AudioClip PickUp_Noise;

    //public GameObject ObjectHolding_Text;
    /*

    public Collider[] ObjectsInRadius;
    public float radius;
    public GameObject Palm;
    public GameObject ArtefactObject;
    
    */


    // Start is called before the first frame update
    void Start()
    {
        Vr_RightHand = GameObject.FindGameObjectWithTag("VR_RightHand");
        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
    }
    //SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
    // Update is called once per frame
    void Update()
    {
        
        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true) // && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
        {
            Gripping = true;
        }

        else
        {
            Gripping = false;

        }

        if (Gripping == true && VR_HoldingObject == false)
        {
            ArtefactObject_StartLocation = ObjectToPickUp.transform.position; //get its start location
            ArtefactObject_StartOrientation = ObjectToPickUp.transform.localEulerAngles; //get its start rotation
            ArtefactObject_Home = ObjectToPickUp.gameObject.transform.parent.gameObject;// get its home display
            ObjectToPickUp.transform.parent = Vr_RightHand.transform; //parent the object to pick up to the player's palm
            ObjectToPickUp.GetComponent<PickUpObject_Hand>().HaloGlow.SetActive(false);

            VR_HoldingObject = true;

            AS.PlayOneShot(PickUp_Noise);

        }

        if (Gripping == false && VR_HoldingObject == true)
        {
            ObjectToPickUp.transform.parent = ArtefactObject_Home.transform;
            ObjectToPickUp.transform.position = ArtefactObject_StartLocation;
            ObjectToPickUp.transform.localEulerAngles = ArtefactObject_StartOrientation;
            VR_HoldingObject = false;
            AS.PlayOneShot(PickUp_Noise);
        }

        
    }

    public void GrippingObject() //function to pick up the object
    {
        //DebugCube.GetComponent<Renderer>().material.color = Color.green; //visual debug

        if (ObjectToPickUp != null) //if there is an object to pick up
        {
            ArtefactObject_StartLocation = ObjectToPickUp.transform.position; //get its start location
            ArtefactObject_StartOrientation = ObjectToPickUp.transform.localEulerAngles; //get its start rotation
            ArtefactObject_Home = ObjectToPickUp.gameObject.transform.parent.gameObject;// get its home display
            ObjectToPickUp.transform.parent = Palm.transform; //parent the object to pick up to the player's palm
            //ObjectHolding_Text.GetComponent<TextMeshProUGUI>().text = ObjectToPickUp.gameObject.name;
            ObjectToPickUp.GetComponent<PickUpObject_Hand>().HaloGlow.SetActive(false);
            AS.PlayOneShot(PickUp_Noise);


        }
        /*
        Debug.Log("Hand Open");
        ObjectsInRadius = Physics.OverlapSphere(Palm.gameObject.transform.position, radius);
        for (int i = 0; i != ObjectsInRadius.Length; i++)
        {
            if (ObjectsInRadius[i].gameObject.tag == "Artefact")
            {
                ArtefactObject = ObjectsInRadius[i].gameObject;
                
            }

        }

        if (ArtefactObject != null)
        {
            ArtefactObject_StartLocation = ArtefactObject.transform.position;
            ArtefactObject_StartOrientation = ArtefactObject.transform.localEulerAngles;
            ArtefactObject_Home = ArtefactObject.gameObject.transform.parent.gameObject;
            ArtefactObject.transform.parent = Palm.transform;
            

        }
        */
    }

    public void UngrippingObject() //function to put the object back
    {
        //DebugCube.GetComponent<Renderer>().material.color = Color.blue; //visual debug
        if (ObjectToPickUp != null)
        {
            //places the object back on its pedestal and parents it back to the pedestal 
            ObjectToPickUp.transform.parent = ArtefactObject_Home.transform;
            ObjectToPickUp.transform.position = ArtefactObject_StartLocation;
            ObjectToPickUp.transform.localEulerAngles = ArtefactObject_StartOrientation;
            AS.PlayOneShot(PickUp_Noise);

            //ObjectHolding_Text.GetComponent<Text>().text = null;
            //ObjectHolding_Text.GetComponent<TextMeshProUGUI>().text = null;



        }
        
        /*
        ArtefactObject.transform.parent = null;
        ArtefactObject = null;
        ObjectsInRadius = new Collider[0];
        */






    }
    

}
