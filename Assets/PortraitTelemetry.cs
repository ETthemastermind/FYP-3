using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitTelemetry : MonoBehaviour
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

    //Standard Telemetry Variables
    //VR Telemtry Variables
    public int Keyword1Said; //increments if the keyword is said
    public int Keyword2Said;
    public int Keyword3Said;
    public int Keyword4Said;

    
    public int PointGestureUsed; // increments if the point gesture is used and a keyword is selected
    public int TellMeAboutThisSaid;

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
        
        DataToPushToMasterTelemetry[0] = ArtefactName; //Name of the Artefact
        DataToPushToMasterTelemetry[1] = TypeOfExhibit; //What type of Exhibit is this
        DataToPushToMasterTelemetry[2] = TimeStamp_Entered; //what time did they get to the exhibit
        DataToPushToMasterTelemetry[3] = TimeStamp_Left; //what time did they leave
        DataToPushToMasterTelemetry[4] = (Artefact.GetComponent<AssignInformation>().keywords[0] + " - " + Keyword1Said).ToString(); //gets the first keyword from this artefact and adds the number of times it was called, same for all the rest with similar lines
        DataToPushToMasterTelemetry[5] = (Artefact.GetComponent<AssignInformation>().keywords[1] + " - " + Keyword2Said).ToString();
        DataToPushToMasterTelemetry[6] = (Artefact.GetComponent<AssignInformation>().keywords[2] + " - " + Keyword3Said).ToString();
        DataToPushToMasterTelemetry[7] = (Artefact.GetComponent<AssignInformation>().keywords[3] + " - " + Keyword4Said).ToString();
        DataToPushToMasterTelemetry[8] = PointGestureUsed.ToString(); // number of times the point gesture is used and a keyword is said
        DataToPushToMasterTelemetry[9] = TellMeAboutThisSaid.ToString(); //number of times "tell me about this" is said with the artefact

        MasterTelemetrySystem.GetComponent<TelemetrySystem>().AddEntry(DataToPushToMasterTelemetry);

        ResetTelemetry();

    }
    
}
