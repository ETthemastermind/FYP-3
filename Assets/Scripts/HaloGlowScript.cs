using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloGlowScript : MonoBehaviour
{
    public GameObject Artefact;
    public GameObject ParentObject;
    // Start is called before the first frame update
    void Start()  //literally exists because im too lazy to to place the halo glows myself
    {
        ParentObject = gameObject.transform.parent.gameObject; //gets parent of the glow i.e whole display
        for (int i = 0; i < ParentObject.transform.childCount; i++) //check the children for the artefact tag and assigns it to the variable
        {
            if (ParentObject.transform.GetChild(i).gameObject.tag == "Artefact")
            {
                Artefact = ParentObject.transform.GetChild(i).gameObject;
            }
        }

        gameObject.transform.position = Artefact.transform.position; //sets position of the halo glow to the same place as the artefact;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
