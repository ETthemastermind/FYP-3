using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait_Interaction : MonoBehaviour
{
    public GameObject TriggerArea;

    public bool PlayerInTrigger = false;

    public string Info1; //who
    public string Info2; //when
    public string Info3; //what
    public string Info4;

    public Text DisplayedInformation;

    public GameObject Portrait_GUI;
    public GameObject Infomation_GUI;

    public Text Keyword1;
    public Text Keyword2;
    public Text Keyword3;
    public Text Keyword4;

    public bool ActiveArtefact = false;
    public bool Dpad_Active_H = false;
    public bool Dpad_Active_V = false;

    public GameObject TelemetrySystem; //reference to the telemetry system on the top level parent
  
    
    // Start is called before the first frame update
    void Awake()
    {
        Portrait_GUI = GameObject.FindGameObjectWithTag("PortraitGUI");
        Infomation_GUI = GameObject.FindGameObjectWithTag("InfoGUI");
        DisplayedInformation = GameObject.FindGameObjectWithTag("Text_Info").GetComponent<Text>();

        Keyword1 = Portrait_GUI.gameObject.transform.GetChild(0).GetComponentInChildren<Text>();
        Keyword2 = Portrait_GUI.gameObject.transform.GetChild(1).GetComponentInChildren<Text>();
        Keyword3 = Portrait_GUI.gameObject.transform.GetChild(2).GetComponentInChildren<Text>();
        Keyword4 = Portrait_GUI.gameObject.transform.GetChild(3).GetComponentInChildren<Text>();
    }

    public void Start()
    {
        Debug.Log("PortraitInteraction start");
        Portrait_GUI.SetActive(false);
        Infomation_GUI.SetActive(false);

        TelemetrySystem = gameObject.transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInTrigger = TriggerArea.GetComponent<AreaEntered>().PlayerInTrigger;

        if (PlayerInTrigger == true & ActiveArtefact == false) //When Player Enters
        {
            ActiveArtefact = true;
            Info1 = gameObject.GetComponent<AssignInformation>().RelevantInfo[0];
            Info2 = gameObject.GetComponent<AssignInformation>().RelevantInfo[1];
            Info3 = gameObject.GetComponent<AssignInformation>().RelevantInfo[2];
            Info4 = gameObject.GetComponent<AssignInformation>().RelevantInfo[3];

            Portrait_GUI.SetActive(true);
            Keyword1.text = gameObject.GetComponent<AssignInformation>().keywords[0];
            Keyword2.text = gameObject.GetComponent<AssignInformation>().keywords[1];
            Keyword3.text = gameObject.GetComponent<AssignInformation>().keywords[2];
            Keyword4.text = gameObject.GetComponent<AssignInformation>().keywords[3];


        }
        else if (PlayerInTrigger == false && ActiveArtefact == true) //When PLayer Exits
        {
            ActiveArtefact = false;
            Portrait_GUI.SetActive(false);
            Infomation_GUI.SetActive(false);


        }

        if (Input.GetAxis("Dpad_Vertical") == 1 && Dpad_Active_V == false && ActiveArtefact == true)
        {
            Infomation_GUI.SetActive(true);
            Dpad_Active_V = true;
            DisplayedInformation.GetComponent<Text>().text = Info1;
            //TelemetrySystem.GetComponent<PortraitTelemetry>().Keyword1Said += 1;  //old system
            TelemetrySystem.GetComponent<PortraitTelemetrySystemV2>().PushData(("SR keyword used - " + Keyword1.text), System.DateTime.Now.ToLongTimeString(),"N/A", "N/A");  //new tel system
            //Debug.Log("Who Active");

        }

        else if (Input.GetAxis("Dpad_Horizontal") == 1 && Dpad_Active_H == false && ActiveArtefact == true)
        {
            Infomation_GUI.SetActive(true);
            Dpad_Active_H = true;
            DisplayedInformation.GetComponent<Text>().text = Info2;

            //TelemetrySystem.GetComponent<PortraitTelemetry>().Keyword2Said += 1;
            TelemetrySystem.GetComponent<PortraitTelemetrySystemV2>().PushData(("SR keyword used - " + Keyword2.text), System.DateTime.Now.ToLongTimeString(), "N/A", "N/A");  //new tel system
            //Debug.Log("When Active");

        }

        else if (Input.GetAxis("Dpad_Horizontal") == -1 && Dpad_Active_H == false && ActiveArtefact == true)
        {
            Infomation_GUI.SetActive(true);
            Dpad_Active_H = true;
            DisplayedInformation.GetComponent<Text>().text = Info4;
            //TelemetrySystem.GetComponent<PortraitTelemetry>().Keyword4Said += 1;
            TelemetrySystem.GetComponent<PortraitTelemetrySystemV2>().PushData(("SR keyword used - " + Keyword4.text), System.DateTime.Now.ToLongTimeString(), "N/A", "N/A");  //new tel system
            //Debug.Log("When Active");

        }

        else if (Input.GetAxis("Dpad_Vertical") == -1 && Dpad_Active_V == false && ActiveArtefact == true)
        {
            Infomation_GUI.SetActive(true);
            Dpad_Active_V = true;
            DisplayedInformation.GetComponent<Text>().text = Info3;
            //TelemetrySystem.GetComponent<PortraitTelemetry>().Keyword3Said += 1;
            TelemetrySystem.GetComponent<PortraitTelemetrySystemV2>().PushData(("SR keyword used - " + Keyword3.text), System.DateTime.Now.ToLongTimeString(), "N/A", "N/A");  //new tel system
            //Debug.Log("When Active");

        }

        if (Input.GetAxis("Dpad_Horizontal") == 0 && Dpad_Active_H == true)// & ActiveArtefact == true)
        {
            Dpad_Active_H = false;
            

        }

        if (Input.GetAxis("Dpad_Vertical") == 0  && Dpad_Active_V == true)// & ActiveArtefact == true)
        {
            Dpad_Active_V = false;

        }






    }
}
