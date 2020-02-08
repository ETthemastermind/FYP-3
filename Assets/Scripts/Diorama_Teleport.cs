using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Diorama_Teleport : MonoBehaviour
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
        PressA = GameObject.FindGameObjectWithTag("Diorama_PressA");
        InfoGUI = GameObject.FindGameObjectWithTag("InfoGUI");
        DisplayedInformation = GameObject.FindGameObjectWithTag("Text_Info").GetComponent<Text>();
    }
    void Start()
    {
        Debug.Log("Diorma Start Function");
        PressA.SetActive(false);
        InfoGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInArea = TriggerArea.GetComponent<AreaEntered>().PlayerInTrigger;

        if (PlayerInArea == true & ActiveArtefact == false)
        {
            ActiveArtefact = true;
            PressA.SetActive(true);
            Keyword1.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[0];
            Keyword2.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[1];
            Keyword3.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[2];
            Keyword4.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().keywords[3];


        }

        if (PlayerInArea == false & ActiveArtefact == true)
        {
            PressA.SetActive(false);
            InfoGUI.SetActive(false);
            ActiveArtefact = false;
            

        }

       

        if (ActiveArtefact == true || InDiorama == true )
        {
            
            Debug.Log("GUI active");

            if (Input.GetButtonDown("Gamepad_A")) //checks to see if the player 
            {
                Debug.Log("Player entering diorama");
                SceneManager.LoadScene(TargetSceneIndex);

            }

            if (Input.GetAxis("Dpad_Vertical") == 1 )
            {
                InfoGUI.SetActive(true);
               
                Debug.Log("Dpad Up");
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[0];

            }
            else if (Input.GetAxis("Dpad_Vertical") == -1 )
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[2];
                Debug.Log("Dpad Down");

            }
            else if (Input.GetAxis("Dpad_Horizontal") == 1 )
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[1];
                Debug.Log("Dpad Right");

            }
            else if (Input.GetAxis("Dpad_Horizontal") == -1 )
            {
                InfoGUI.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[3];
                Debug.Log("Dpad Left");

            }
            

        }

        
        
    }

    
}
