using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

public class Artefact_Hand_PickUp : MonoBehaviour //
{


    public GameObject DebugCube;
    public GameObject ObjectToPickUp = null; //object to pick up, gotten from PickUpObject_Hand script
    public GameObject ArtefactPickedUp;
    public Vector3 ArtefactObject_StartLocation; //reference for the location the artefact starts at
    public Vector3 ArtefactObject_StartOrientation; //reference for the rotation the artefact starts at
    public GameObject ArtefactObject_Home; //refeernce for the home display of the object
    public GameObject Palm; // reference the leap motion palm, right hand

    public GameObject Vr_RightHand;
    public GameObject Vr_LeftHand;
    public GameObject GrippedHand;
    public bool VR_HoldingObject;
    public bool Gripping;

    public bool UsingVRHands = true;

    public GameObject Player;
    public AudioSource AS;
    public AudioClip PickUp_Noise;

    public GameObject Parent;

    
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
        Vr_LeftHand = GameObject.FindGameObjectWithTag("VR_LeftHand");
        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
        //ObjectToPickUp = this.gameObject;
    }
    //SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
    // Update is called once per frame
    void Update()
    {
        Debug.Log(ObjectToPickUp);
        
        if (UsingVRHands == true)
        {
            if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true) // && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
            {
                Gripping = true;
                GrippedHand = Vr_RightHand;

            }

            else if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.LeftHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.LeftHand) == true) // && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true
            {
                Gripping = true;
                GrippedHand = Vr_LeftHand;
            }

            else
            {
                Gripping = false;
                GrippedHand = null;

            }

            if (Gripping == true && VR_HoldingObject == false && ObjectToPickUp.name != this.gameObject.name)
            {

                Debug.Log("PickedUp");
                Parent = ObjectToPickUp.transform.parent.gameObject;
                ObjectToPickUp.transform.parent.gameObject.GetComponent<PickupArtefactTelemetry>().TimePickedUp = System.DateTime.Now.ToLongTimeString(); //gives the telemetry a timestamp for when the artefact gets picked up
                ObjectToPickUp.transform.parent.gameObject.GetComponent<PickupArtefactTelemetry>().ArtefactPickedUp += 1; //gives the telemetry a timestamp for when the artefact gets picked up
                ArtefactObject_StartLocation = ObjectToPickUp.transform.position; //get its start location
                ArtefactObject_StartOrientation = ObjectToPickUp.transform.localEulerAngles; //get its start rotation
                ArtefactObject_Home = ObjectToPickUp.gameObject.transform.parent.gameObject;// get its home display
                ObjectToPickUp.transform.parent = GrippedHand.transform; //parent the object to pick up to the player's palm
                ObjectToPickUp.GetComponent<PickUpObject_Hand>().HaloGlow.SetActive(false);
                VR_HoldingObject = true;

                AS.PlayOneShot(PickUp_Noise);
                Debug.Log("Send Data");


                Debug.Log("Data Sent");

            }

            else if (Gripping == false && VR_HoldingObject == true)
            {

                ObjectToPickUp.transform.parent = ArtefactObject_Home.transform;
                ObjectToPickUp.transform.position = ArtefactObject_StartLocation;
                ObjectToPickUp.transform.localEulerAngles = ArtefactObject_StartOrientation;
                VR_HoldingObject = false;
                AS.PlayOneShot(PickUp_Noise);
                GrippedHand = null;


                ObjectToPickUp.transform.parent.gameObject.GetComponent<PickupArtefactTelemetry>().TimePutDown = System.DateTime.Now.ToLongTimeString(); //gives the telemetry a timestamp for when the artefact gets picked up
                ObjectToPickUp = this.gameObject;
            }

            else
            {

            }

        }
        

        
    }

    public void GrippingObject() //function to pick up the object
    {
        if (Gripping == false)
        {
            Debug.Log("LM Hand Gripped");

            Debug.Log(ObjectToPickUp + "Gripped");
            if (ObjectToPickUp == null)
            {
                Debug.Log("NoObjectToPickUp");
            }
            else
            {
                Gripping = true;
                ArtefactObject_Home = ObjectToPickUp.gameObject.transform.parent.gameObject;// get its home display
                ArtefactObject_StartLocation = ObjectToPickUp.transform.position;
                ArtefactObject_StartOrientation = ObjectToPickUp.transform.localEulerAngles; //get its start rotation
                ObjectToPickUp.transform.parent = Palm.transform; //parent the object to pick up to the player's palm
                ObjectToPickUp.GetComponent<PickUpObject_Hand>().HaloGlow.SetActive(false);
                ArtefactPickedUp = ObjectToPickUp;
                AS.PlayOneShot(PickUp_Noise);

            }

        }
        //DebugCube.GetComponent<Renderer>().material.color = Color.green; //visual debug
        
        
        
        




        //ObjectHolding_Text.GetComponent<TextMeshProUGUI>().text = ObjectToPickUp.gameObject.name;


        
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
        if (Gripping == true)
        {
            Debug.Log("LM Hand Ungripped");

            ArtefactPickedUp.transform.parent = ArtefactObject_Home.transform;

            ArtefactPickedUp.transform.position = ArtefactObject_StartLocation;

            ArtefactPickedUp.transform.localEulerAngles = ArtefactObject_StartOrientation;

            ArtefactPickedUp = null;
            AS.PlayOneShot(PickUp_Noise);

            Gripping = false;
            //DebugCube.GetComponent<Renderer>().material.color = Color.blue; //visual debug


            /*
            ArtefactObject.transform.parent = null;
            ArtefactObject = null;
            ObjectsInRadius = new Collider[0];
            */

        }







    }

    public void GetArtefact(GameObject ArtefactInProx)
    {
        ObjectToPickUp = ArtefactInProx;

    }


}
