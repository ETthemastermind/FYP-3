using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaExhibitTelemetryV2 : MonoBehaviour
{

    public GameObject InteractRing;
    public bool PlayerInInteractRing;
    public string TimeStamp;
    public bool Entered;

    public string[] DataLog;
    public GameObject MasterTelemetrySystem;

    public GameObject Artefact;
    public string ArtefactName;
    public string TypeOfArtefact;

    // Start is called before the first frame update
    void Start()
    {

        MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.tag == "Artefact")
            {
                Artefact = gameObject.transform.GetChild(i).gameObject;
                ArtefactName = Artefact.name;

            }

            string Comma = ",";
            int j = ArtefactName.IndexOf(Comma);
            if (j >= 0)
            {
                ArtefactName = ArtefactName.Remove(j, Comma.Length);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInInteractRing = InteractRing.GetComponent<AreaEntered>().PlayerInTrigger;
        if (PlayerInInteractRing == true && Entered == false)
        {
            
            Entered= true;
            string TypeOfInteractionUsed = "Exhibit Visited";
            PushData(TypeOfInteractionUsed);
        }


        else if (PlayerInInteractRing == false && Entered== true)
        {
            string TimeStamp2 = System.DateTime.Now.ToLongTimeString();
            Entered = false;
            string TypeOfInteractionUsed = "Exhibit Left";
            PushData(TypeOfInteractionUsed);
        }
    }

    public void PushData(string TypeOfInteractionUsed)
    {
        DataLog[0] = ArtefactName;
        DataLog[1] = TypeOfArtefact;
        DataLog[2] = TypeOfInteractionUsed;
        DataLog[3] = System.DateTime.Now.ToString("hh.mm.ss.ffffff");


        if (MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().TelemetryActive == true)
        {
            MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry(DataLog);
            Debug.Log("Diorama Data Pushed");
        }

        
    }
}
