﻿using System.Collections;
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

    public GameObject InfoGUI;
    public Text DisplayedInformation;

    public GameObject Keyword1;  
    public GameObject Keyword2;
    public GameObject Keyword3;
    public GameObject Keyword4;



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
    }
    void Start()
    {
        Debug.Log("Diorma Start Function");
        PressA.SetActive(false); //sets the GUI to false
        InfoGUI.SetActive(false); //sets the GUI to false
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
                

            }

            if (Input.GetAxis("Dpad_Vertical") == 1 ) //if up on the dpad is pressed
            {
                InfoGUI.SetActive(true);
               
                Debug.Log("Dpad Up");
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[0]; //show the first line of information

            }
            else if (Input.GetAxis("Dpad_Vertical") == -1 ) //if down on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[2]; //show the third line of information
                Debug.Log("Dpad Down");

            }
            else if (Input.GetAxis("Dpad_Horizontal") == 1 ) //if right on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[1]; //show the second line of information
                Debug.Log("Dpad Right");

            }
            else if (Input.GetAxis("Dpad_Horizontal") == -1 ) //if left on the dpad is pressed
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[3]; //show the fourth line of information
                Debug.Log("Dpad Left");

            }
            

        }


        
        
    }

    public void TeleportPlayer()
    {
        Debug.Log("Player entering diorama");
        SceneManager.LoadScene(TargetSceneIndex); //teleport area to the diorama
    }

    
}
