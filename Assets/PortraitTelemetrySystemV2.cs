using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitTelemetrySystemV2 : MonoBehaviour
{
    public GameObject InteractRing;
    public bool PlayerInInteractRing;
    public string TimeStamp;
    public bool TimeEntered_Found;

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
        //Getting time stamps for entering and leaving//==============================================================
        PlayerInInteractRing = InteractRing.GetComponent<AreaEntered>().PlayerInTrigger;
        if (PlayerInInteractRing == true && TimeEntered_Found == false)
        {
            TimeStamp = System.DateTime.Now.ToLongTimeString();
            TimeEntered_Found = true;
        }


        else if (PlayerInInteractRing == false && TimeEntered_Found == true)
        {
            string TimeStamp2 = System.DateTime.Now.ToLongTimeString();
            TimeEntered_Found = false;
            string TypeOfInteractionUsed = "Exhibit Vistied";
            string InteractionCompleted = "True";
            PushData(TypeOfInteractionUsed, InteractionCompleted, TimeStamp2);
            

            

        }

    }

    public void PushData(string TypeOfInteractionUsed, string InteractionCompleted,string TimeStamp2)
    {
        DataLog[0] = ArtefactName;
        DataLog[1] = TypeOfArtefact;
        DataLog[2] = TypeOfInteractionUsed;
        DataLog[3] = TimeStamp;
        DataLog[4] = InteractionCompleted;
        DataLog[5] = TimeStamp2;

        MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry(DataLog);

        
    }
}
