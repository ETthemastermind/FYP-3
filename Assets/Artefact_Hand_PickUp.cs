using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Artefact_Hand_PickUp : MonoBehaviour
{


    public GameObject DebugCube;
    public GameObject ObjectToPickUp;
    public Vector3 ArtefactObject_StartLocation;
    public Vector3 ArtefactObject_StartOrientation;
    public GameObject ArtefactObject_Home;
    public GameObject Palm;

    public GameObject ObjectHolding_Text;
    /*

    public Collider[] ObjectsInRadius;
    public float radius;
    public GameObject Palm;
    public GameObject ArtefactObject;
    
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GrippingObject()
    {
        DebugCube.GetComponent<Renderer>().material.color = Color.green; //visual debug

        if (ObjectToPickUp != null)
        {
            ArtefactObject_StartLocation = ObjectToPickUp.transform.position;
            ArtefactObject_StartOrientation = ObjectToPickUp.transform.localEulerAngles;
            ArtefactObject_Home = ObjectToPickUp.gameObject.transform.parent.gameObject;
            ObjectToPickUp.transform.parent = Palm.transform;
            ObjectHolding_Text.GetComponent<TextMeshProUGUI>().text = ObjectToPickUp.gameObject.name;


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

    public void UngrippingObject()
    {
        DebugCube.GetComponent<Renderer>().material.color = Color.blue; //visual debug
        if (ObjectToPickUp != null)
        {
            
            ObjectToPickUp.transform.parent = ArtefactObject_Home.transform;
            ObjectToPickUp.transform.position = ArtefactObject_StartLocation;
            ObjectToPickUp.transform.localEulerAngles = ArtefactObject_StartOrientation;
            
            //ObjectHolding_Text.GetComponent<Text>().text = null;
            ObjectHolding_Text.GetComponent<TextMeshProUGUI>().text = null;
            


        }
        
        /*
        ArtefactObject.transform.parent = null;
        ArtefactObject = null;
        ObjectsInRadius = new Collider[0];
        */






    }
    

}
