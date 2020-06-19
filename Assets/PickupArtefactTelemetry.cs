using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArtefactTelemetry : MonoBehaviour
{
    //General Telemetry Variables

    public string TimeStamp_Entered;
    public bool TimeEntered_Found;
    public string TimeStamp_Left;
    public bool TimeLeftFound_Found;
    public string TypeOfExhibit;
    public string ArtefactName;
    public GameObject Artefact;


    public string[] DataToPushToMasterTelemetry;
    public GameObject MasterTelemetrySystem;

    //universal variables for each version
    public int Keyword1Said;
    public int Keyword2Said;
    public int Keyword3Said;
    public int Keyword4Said;
    public int ArtefactPickedUp;
    public string TimePickedUp;
    public string TimePutDown;

    //Standard Telemetry Variables
    public int S_ObjectRotated;
    public int S_ObjectScaled;
    //VR Telemtry Variables
    

    //VR+ Telemtry Variables
    //other needed Variables
    public GameObject InteractRing;
    public bool PlayerInInteractRing;
    public GameObject Player;





    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.tag == "Artefact")
            {
                Artefact = gameObject.transform.GetChild(i).gameObject;
                ArtefactName = Artefact.name;

            }


        }

        string Comma = ",";
        int j = ArtefactName.IndexOf(Comma);
        if (j >= 0)
        {
            ArtefactName = ArtefactName.Remove(j, Comma.Length);
        }


        MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Getting time stamps for entering and leaving//==============================================================
        PlayerInInteractRing = InteractRing.GetComponent<AreaEntered>().PlayerInTrigger;
        if (PlayerInInteractRing == true && TimeEntered_Found == false)
        {
            TimeStamp_Entered = System.DateTime.Now.ToLongTimeString();
            TimeEntered_Found = true;
        }


        else if (PlayerInInteractRing == false && TimeEntered_Found == true)
        {
            TimeStamp_Left = System.DateTime.Now.ToLongTimeString();
            TimeEntered_Found = false;
            GatherData();

        }




    }

    public void ResetTelemetry()
    {
        Debug.Log("Resetting Telemetry");
        TimeStamp_Entered = null;
        TimeStamp_Left = null;
    }

    public void GatherData()
    {

        DataToPushToMasterTelemetry[0] = ArtefactName; //Artefact Name
        DataToPushToMasterTelemetry[1] = TypeOfExhibit; //What type of Exhibit is this
        DataToPushToMasterTelemetry[2] = TimeStamp_Entered; //what time did they get to the exhibit
        DataToPushToMasterTelemetry[3] = TimeStamp_Left; //what time did they leave
        DataToPushToMasterTelemetry[4] = (Artefact.GetComponent<AssignInformation>().keywords[0] + " - " + Keyword1Said).ToString(); //gets the first keyword from this artefact and adds the number of times it was called, same for all the rest with similar lines
        DataToPushToMasterTelemetry[5] = (Artefact.GetComponent<AssignInformation>().keywords[1] + " - " + Keyword2Said).ToString();
        DataToPushToMasterTelemetry[6] = (Artefact.GetComponent<AssignInformation>().keywords[2] + " - " + Keyword3Said).ToString();
        DataToPushToMasterTelemetry[7] = (Artefact.GetComponent<AssignInformation>().keywords[3] + " - " + Keyword4Said).ToString();
        DataToPushToMasterTelemetry[8] = ArtefactPickedUp.ToString();
        DataToPushToMasterTelemetry[9] = S_ObjectScaled.ToString();
        DataToPushToMasterTelemetry[10] = S_ObjectRotated.ToString();

        //DataToPushToMasterTelemetry[9] = TimePickedUp;
        //DataToPushToMasterTelemetry[10] = TimePutDown;



        MasterTelemetrySystem.GetComponent<TelemetrySystem>().AddEntry(DataToPushToMasterTelemetry);

        ResetTelemetry();

    }

}

