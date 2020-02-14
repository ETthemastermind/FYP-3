using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointingGesture : MonoBehaviour
{

    public GameObject FingerTip; //assings the finger tip to shoot the ray from
    public bool _isPointing = false; //bool to find out if the player is pointing

    public List<GameObject> childrenObjects = new List<GameObject>(); //creates a list of children objects of the object pointed at
    public GameObject ObjectPointedAt; //gets the object pointed at
    public GameObject Artefact; //references the actual artefact from the object pointed at
    public GameObject KeywordObject;
    private Transform ChildToCheck; //temp object that gets assinged each child object whilst in a loop

    public LineRenderer LR;

    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        


        
        if (_isPointing == true) //if the player is pointing
        {
            Ray PointRay = new Ray(FingerTip.transform.position, FingerTip.transform.forward); //creates the ray
            Debug.DrawRay(FingerTip.transform.position, FingerTip.transform.forward * 50f, Color.green); //debug for the ray

            LR.SetPosition(0, FingerTip.transform.position);
            LR.SetPosition(1, FingerTip.transform.forward * 50f);

            RaycastHit ObjectHit;


            if (Physics.Raycast(PointRay, out ObjectHit, 100f)) //if an object is hit
            {
                
                Debug.Log(ObjectHit.collider.transform.childCount); //prints the name of the hit object
                ObjectPointedAt = ObjectHit.collider.gameObject; //assigns the object pointed at to a game object
                if (ObjectPointedAt.gameObject.tag == "Keyword")
                {
                    KeywordObject = ObjectPointedAt.gameObject;

                    //Debug.Log(KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

                }

                else
                {
                    if (KeywordObject != null)
                    {
                        KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                        KeywordObject = null;

                    }
                    for (int i = 0; i < ObjectHit.collider.transform.childCount; i++) //for each child of the hit object
                    {

                        ChildToCheck = ObjectHit.collider.transform.GetChild(i); //assigns the current child to a temp variable
                        if (ChildToCheck.gameObject.tag == "Artefact") //checks to see if that child object has the artefact tag
                        {
                            Artefact = ObjectHit.collider.transform.GetChild(i).gameObject; //assings child with artefact tag to a variables

                        }


                    }

                }
                

                Debug.Log(ObjectPointedAt.gameObject.name + " is being pointed at"); //prints name of hit object to console
                //Debug.Log("Artefact Name:" + Artefact.name);
                //Artefact.SendMessage("PortraitSelected"); //activates function on the artefact object to change the material

            }
            else
            {
                //Artefact.SendMessage("PortraitUnselected"); //activates function on the artefact object to change the material
              
                Artefact = null;
                ChildToCheck = null;
                ObjectPointedAt = null;
                KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                KeywordObject = null;

                

            }
        }
    }

    public void isPointing() //if the player is pointing
    {
        _isPointing = true; //activates the pointing variable
        Debug.Log("Is Pointing");

    }

    public void isNotPointing()
    {
        //Artefact.SendMessage("PortraitUnselected"); //activates function on the artefact object to change the material
        _isPointing = false; //resets variables 
        Artefact = null;
        ChildToCheck = null;
        ObjectPointedAt = null;
        
        Debug.Log("Is Not Pointing");


    }

   
   

}
