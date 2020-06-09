using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExhibitObserver : MonoBehaviour
{
    public bool UserInRing;
    private GameObject InteractRing;
    public GameObject Artefact;
    private GameObject ParentDisplay;

    //Artefact Info
    public string ArtifactName;
    public string[] RelevantInfo;
    public AudioClip[] AudioInfo;
    public string[] Keywords;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractRing")
        {
            UserInRing = true;
            InteractRing = other.gameObject;
            ParentDisplay = InteractRing.transform.parent.gameObject;
            for (int i = 0; i < ParentDisplay.transform.childCount; i++)
            {
                Debug.Log(ParentDisplay.transform.GetChild(i).gameObject);


                
                if ((ParentDisplay.transform.GetChild(i).gameObject.tag == "Artefact"))
                {
                    Artefact = ParentDisplay.transform.GetChild(i).gameObject;
                }


                ArtifactName = Artefact.gameObject.name;

                for (int A = 0; A < 3; A++)
                {
                    RelevantInfo[A] = Artefact.GetComponent<AssignInformation>().RelevantInfo[A];
                }
                
                   
            }


        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractRing")
        {
            UserInRing = false;
            Artefact = null;
            InteractRing = null;
        }
    }
}
