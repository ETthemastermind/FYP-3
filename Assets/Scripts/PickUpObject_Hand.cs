﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject_Hand : MonoBehaviour
{
    //public GameObject DebugCube;
    public GameObject PickUpController; // reference to the object under the player object that controls other pick up mechanics

    public Rigidbody RB; //reference to the rigid body component

    public GameObject HaloGlow; // reference to the halo glow component attatched to the display

    public GameObject Parent; //reference to the display pedestal itself







    //new variables
    public AudioClip PickUpNoise;
    public AudioClip PutDownNoise;
    public GameObject Player;
    public AudioSource AS;


    //ArtefactStartingVariables
    public Vector3 Start_Location;
    public Vector3 Start_Rotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //PickUpController = GameObject.FindGameObjectWithTag("PickUpController"); //finds the pick up controller attatched to the player
        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
        RB = gameObject.GetComponent<Rigidbody>(); //gets the rigid body from the artefact


        Start_Location = gameObject.transform.position;
        Start_Rotation = gameObject.transform.localEulerAngles;

        /*
        Parent = gameObject.transform.parent.gameObject; //finds the parent display, so it can be returned to the right place
        for (int i = 0; i < Parent.transform.childCount; i++) // find the halo component
        {
            if (Parent.transform.GetChild(i).gameObject.name == "Halo")
            {
                HaloGlow = Parent.transform.GetChild(i).gameObject;

            }

        }

        HaloGlow.SetActive(false); //turn it off by default
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "VR_RightHand" || other.gameObject.tag == "VR_LeftHand") //if a hand is in the object's trigger area
        {
            //DebugCube.GetComponent<Renderer>().material.color = Color.red; //visual debug
            //PickUpController.GetComponent<Artefact_Hand_PickUp>().ObjectToPickUp = gameObject; //assigns the pickup object of the pickup controller to this object
            PickUpController.GetComponent<Artefact_Hand_PickUp>().GetArtefact(this.gameObject);
            HaloGlow.SetActive(true); //turns the halo on
            Debug.Log("Hand Entered" + gameObject.name.ToString());


        }

        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "VR_RightHand" || other.gameObject.tag == "Left Hand" || other.gameObject.tag == "VR_LeftHand") //if a hand has left the objects trigger area
        {
            //DebugCube.GetComponent<Renderer>().material.color = Color.white; //visual debug
            PickUpController.GetComponent<Artefact_Hand_PickUp>().ObjectToPickUp = null; //clears the object to pick up
            //PickUpController.GetComponent<Artefact_Hand_PickUp>().GetArtefact(PickUpController);
            HaloGlow.SetActive(false); //turns the halo off
        }
    }

    */

    public void OnPickedUp()
    {
        AS.PlayOneShot(PickUpNoise);
    }

    public void OnPutDown()
    {
        gameObject.transform.position = Start_Location;
        gameObject.transform.localEulerAngles = Start_Rotation;
        AS.PlayOneShot(PutDownNoise);
    }

   
}
