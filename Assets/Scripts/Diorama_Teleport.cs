using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Diorama_Teleport : MonoBehaviour   //Gamepad teleporting
{
    public string DisplayName;
    public GameObject PressA; //gets the press A GUI text as a game object
    public int TargetSceneIndex; //lets me input the scene index in editor


    public GameObject TriggerArea;
    public bool PlayerInArea = false; 

    public bool ActiveArtefact = false;

    public bool InDiorama = false;

    public GameObject InfoGUI;  //GUI references
    public Text DisplayedInformation;

    public GameObject Keyword1;  
    public GameObject Keyword2;
    public GameObject Keyword3;
    public GameObject Keyword4;
    public GameObject LoadingScreen;

    public GameObject ModalityController;

    public bool Dpad_Active_H;
    public bool Dpad_Active_V;



    // Start is called before the first frame update
    private void Awake()
    {
        PressA = GameObject.FindGameObjectWithTag("Diorama_PressA"); //finds relevant GUI gameobkects by tag
        InfoGUI = GameObject.FindGameObjectWithTag("InfoGUI");
        DisplayedInformation = GameObject.FindGameObjectWithTag("Text_Info").GetComponent<Text>();
        Keyword1 = GameObject.FindGameObjectWithTag("DD_KW_1");
        Keyword2 = GameObject.FindGameObjectWithTag("DD_KW_2");
        Keyword3 = GameObject.FindGameObjectWithTag("DD_KW_3");
        Keyword4 = GameObject.FindGameObjectWithTag("DD_KW_4");
        LoadingScreen = GameObject.FindGameObjectWithTag("GP_LoadingScreen");
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
    }
    void Start()
    {
        Debug.Log("Diorma Start Function");
        PressA.SetActive(false); //sets the GUI to false
        InfoGUI.SetActive(false); //sets the GUI to false
        LoadingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInArea = TriggerArea.GetComponent<AreaEntered>().PlayerInTrigger;

        if (PlayerInArea == true & ActiveArtefact == false) //if player is in the trigger and the script is active
        {
            ActiveArtefact = true; 
            PressA.SetActive(true);
            Keyword1.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[0]; //assings the keywords for the GUI 
            Keyword2.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[1];
            Keyword3.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[2];
            Keyword4.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[3];


        }

        if (PlayerInArea == false & ActiveArtefact == true)
        {
            PressA.SetActive(false); //turns GUI back off and active artefact off
            InfoGUI.SetActive(false);
            ActiveArtefact = false;
            

        }

       

        if (ActiveArtefact == true || InDiorama == true ) //not quite sure why theres an or there but not going to change it
        {
            
            Debug.Log("GUI active");

            if (Input.GetButtonDown("Gamepad_A")) //checks to see if the player has pressed A
            {
                Debug.Log("Player entering diorama");
                PressA.SetActive(false);
                LoadingScreen.SetActive(true);
                ModalityController.GetComponent<ModalityController2>().GamepadPlayer_Return = GameObject.FindGameObjectWithTag("Player").transform.position;
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().DioramaEntered += 1;
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().DioramaEnteredTel();
                gameObject.transform.parent.GetComponent<DioramaExhibitTelemetryV2>().PushData("Diorama Entered");
                SceneManager.LoadSceneAsync(TargetSceneIndex); //teleport area to the diorama

            }

            if (Input.GetAxis("Dpad_Vertical") == 1 && Dpad_Active_V == false) //if up on the dpad is pressed
            {
                InfoGUI.SetActive(true);

                Debug.Log("Dpad Up");
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[0]; //show the first line of information
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().Keyword1Said += 1;
                gameObject.transform.parent.GetComponent<DioramaExhibitTelemetryV2>().PushData("Dpad Keyword Used - " + Keyword1.GetComponent<Text>().text);
                Dpad_Active_V = true;

            }
            else if (Input.GetAxis("Dpad_Vertical") == -1 && Dpad_Active_V == false) //if down on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[2]; //show the third line of information
                Debug.Log("Dpad Down");
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().Keyword2Said += 1;
                gameObject.transform.parent.GetComponent<DioramaExhibitTelemetryV2>().PushData("Dpad Keyword Used - " + Keyword2.GetComponent<Text>().text);
                Dpad_Active_V = true;

            }
            else if (Input.GetAxis("Dpad_Horizontal") == 1 && Dpad_Active_H == false) //if right on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[1]; //show the second line of information
                Debug.Log("Dpad Right");
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().Keyword3Said += 1;
                gameObject.transform.parent.GetComponent<DioramaExhibitTelemetryV2>().PushData("Dpad Keyword Used - " + Keyword3.GetComponent<Text>().text);
                Dpad_Active_H = true;
            }
            else if (Input.GetAxis("Dpad_Horizontal") == -1 && Dpad_Active_H == false) //if left on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[3]; //show the fourth line of information
                Debug.Log("Dpad Left");
                //gameObject.transform.parent.GetComponent<DioramaExhibitTelemetry>().Keyword4Said += 1;
                gameObject.transform.parent.GetComponent<DioramaExhibitTelemetryV2>().PushData("Dpad Keyword Used - " + Keyword4.GetComponent<Text>().text);
                Dpad_Active_H = true;

            }
            else if (Input.GetAxis("Dpad_Vertical") == 0 && Dpad_Active_V == true)
            {
                Dpad_Active_V = false;
            }
            else if (Input.GetAxis("Dpad_Horizontal") == 0 && Dpad_Active_H == true)
            {
                Dpad_Active_H = false;
            }


        }

        
        
    }

    
}
