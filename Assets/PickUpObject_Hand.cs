using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject_Hand : MonoBehaviour
{
    //public GameObject DebugCube;
    public GameObject PickUpController;

    public Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        PickUpController = GameObject.FindGameObjectWithTag("PickUpController");
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "Left Hand") //if a hand is in the object's trigger area
        {
            //DebugCube.GetComponent<Renderer>().material.color = Color.red; //visual debug
            PickUpController.GetComponent<Artefact_Hand_PickUp>().ObjectToPickUp = gameObject;


        }

        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "Left Hand") //if a hand has left the objects trigger area
        {
            //DebugCube.GetComponent<Renderer>().material.color = Color.white; //visual debug
            PickUpController.GetComponent<Artefact_Hand_PickUp>().ObjectToPickUp = null;
            
        }
    }
}
