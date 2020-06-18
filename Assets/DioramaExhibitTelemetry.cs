using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DioramaExhibitTelemetry : MonoBehaviour
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

    //universal variables for each modalityu
    public int DioramaEntered;
    //Standard Telemetry Variables
    //VR Telemtry Variables
    public int Keyword1Said;
    public int Keyword2Said;
    public int Keyword3Said;
    public int Keyword4Said;

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

    public void GatherData() //gather data and push to the master telemetry handler object
    {

        DataToPushToMasterTelemetry[0] = ArtefactName;
        DataToPushToMasterTelemetry[1] = TypeOfExhibit;
        DataToPushToMasterTelemetry[2] = TimeStamp_Entered;
        DataToPushToMasterTelemetry[3] = TimeStamp_Left;
        DataToPushToMasterTelemetry[4] = (Artefact.GetComponent<AssignInformation>().keywords[0] + " - " + Keyword1Said).ToString();
        DataToPushToMasterTelemetry[5] = (Artefact.GetComponent<AssignInformation>().keywords[1] + " - " + Keyword2Said).ToString();
        DataToPushToMasterTelemetry[6] = (Artefact.GetComponent<AssignInformation>().keywords[2] + " - " + Keyword3Said).ToString();
        DataToPushToMasterTelemetry[7] = (Artefact.GetComponent<AssignInformation>().keywords[3] + " - " + Keyword4Said).ToString();
        DataToPushToMasterTelemetry[8] = DioramaEntered.ToString();

        MasterTelemetrySystem.GetComponent<TelemetrySystem>().AddEntry(DataToPushToMasterTelemetry);

        ResetTelemetry();

    }

    public void DioramaEnteredTel() //if the player teleports, get the timestamp when they pressed A and make that the timestamp_left
    {
        TimeStamp_Left = System.DateTime.Now.ToLongTimeString();
        TimeEntered_Found = false;
        GatherData();
    }


    public void OnApplicationQuit()
    {
        if (PlayerInInteractRing == true)
        {
            TimeStamp_Left = System.DateTime.Now.ToLongTimeString();
            TimeEntered_Found = false;
            GatherData();
        }
    }


}

