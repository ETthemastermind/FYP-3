using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;


public class ModalityController2 : MonoBehaviour  //due to the dont destroy on load, might as well keep anything that needs to be kept across scenes here
{
    public bool Gamepad_Chosen;
    public bool GamepadFirstSpawned; //checks to see if the player has already been spawned, purpose is to allow the player to return to where they left when going to diorama scenes
    public bool VRSR_Chosen;
    public bool VRLMSR_Chosen;
    public bool TestingModeActivated;

    public int SceneToLoad;
    public GameObject IdentifierInputBox;
    public GameObject NoModalitySelected;
    public GameObject TelemetrySystem;
    public bool DataMissing;

    //refs to canvas
    public GameObject MainMenuCanvas;
    public GameObject TestingCanvas;
    public GameObject LoadingCanvas;
    public GameObject FileAddessText;

    //refs for buttons to change colors

    public GameObject Gamepad_Button;
    public GameObject VRSR_Button;
    public GameObject VRSRLM_Button;


    //testing canvas variables 
    public GameObject Version_InputBox;

    

    public bool TutorialCompleted; //is this persists across scenes, might as well use it for variables to carry across scenes.
    //diorama return variables

    public Vector3 GamepadPlayer_Return; // vector 3 coords, assinged by the diorama artifacts when the player changes scenes
    public bool FirstMusSpawn;

    public bool ReturningGamepad;
    public GameObject Player;



    //Test Variables
    public string UserIdentifier;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); //keeps the modality controller persistent between scenes
        XRSettings.enabled = false;
        TelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
        Player = GameObject.FindGameObjectWithTag("Player");

        //Version_InputBox.GetComponent<Text>().text = "Set Version";

        FileAddessText.GetComponent<TextMeshProUGUI>().text = Application.persistentDataPath + "/Telemetry.csv";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamepadModality()
    {
        Gamepad_Chosen = true; //activates the boolean so that the controllers in the museum scenes reference the correct controller
        VRSR_Chosen = false;
        VRLMSR_Chosen = false;
        NoModalitySelected.SetActive(false);

        Gamepad_Button.GetComponent<Image>().color = Color.green;
        VRSR_Button.GetComponent<Image>().color = Color.white;
        VRSRLM_Button.GetComponent<Image>().color = Color.white;

        Version_InputBox.GetComponent<TMP_InputField>().text = "Standard";
        






    }

    public void VRSRModality()
    {
        Gamepad_Chosen = false; //activates the boolean so that the controllers in the museum scenes reference the correct controller
        VRSR_Chosen = true;
        VRLMSR_Chosen = false;
        NoModalitySelected.SetActive(false);

        Gamepad_Button.GetComponent<Image>().color = Color.white; //change color of the buttons to indicate choice
        VRSR_Button.GetComponent<Image>().color = Color.green;
        VRSRLM_Button.GetComponent<Image>().color = Color.white;

        Version_InputBox.GetComponent<TMP_InputField>().text = "VR";
        


    }

    public void VRSRLMModality()
    {
        Gamepad_Chosen = false; //activates the boolean so that the controllers in the museum scenes reference the correct controller
        VRSR_Chosen = false;
        VRLMSR_Chosen = true;
        NoModalitySelected.SetActive(false);

        Gamepad_Button.GetComponent<Image>().color = Color.white;
        VRSR_Button.GetComponent<Image>().color = Color.white;
        VRSRLM_Button.GetComponent<Image>().color = Color.green;

        Version_InputBox.GetComponent<TMP_InputField>().text = "VR+";
        



    }

    public void LoadLevel()
    {
        if (Gamepad_Chosen == false && VRSR_Chosen == false && VRLMSR_Chosen == false) //check to see if the user has chosen a modality
        {
             //show error message
            


        }
        else
        {
            MainMenuCanvas.SetActive(false);
            TestingCanvas.SetActive(false);
            LoadingCanvas.SetActive(true);
            SceneManager.LoadSceneAsync(SceneToLoad); //keep the music playing while loading
            
        }
        /*
        if (TestingModeActivated == false)
        {
            Debug.Log("Level Loading");
            SceneManager.LoadScene(SceneToLoad);
        }
        */
        
    }

    public void TestingModeButtonPress()
    {
        /*
        if (IdentifierInputBox.GetComponent<TMP_InputField>().interactable == true)
        {
            IdentifierInputBox.GetComponent<TMP_InputField>().interactable = false;
            TestingModeActivated = false;
        }
        else
        {
            IdentifierInputBox.GetComponent<TMP_InputField>().interactable = true;
            TestingModeActivated = true;

        }
       */

        if (TestingModeActivated == true)
        {
            TestingModeActivated = false;
        }
        else if (TestingModeActivated == false)
        {
            TestingModeActivated = true;
            
        }
    }

    public void BeginPlay()
    {
        Debug.Log("Begin Play Pressed");
        if (Gamepad_Chosen == false && VRSR_Chosen == false && VRLMSR_Chosen == false) // check to see if the user has chosen a modality)
        {
            NoModalitySelected.SetActive(true);
        }
        else
        {
            if (TestingModeActivated == false)
            {
                //TelemetrySystem.GetComponent<TelemetrySystem>().enabled = false;
                MainMenuCanvas.SetActive(false);
                TestingCanvas.SetActive(false);
                LoadingCanvas.SetActive(true);
                SceneManager.LoadSceneAsync(SceneToLoad); //keep the music playing while loading

            }
            else if (TestingModeActivated == true)
            {
                Debug.Log("Turn Main Menu Canvas Off");
                MainMenuCanvas.SetActive(false);
                TestingCanvas.SetActive(true);
                TelemetrySystem.GetComponent<TelemetrySystemV2>().TelemetryActive = true;
            TelemetrySystem.GetComponent<TelemetrySystemV2>().CreateFiles();





            }
        } 
        
       
    }

    public void BeginTest()
    {

        DataMissing = false;
        Debug.Log("Load Testing Mode");

        for (int i = 0; i < TelemetrySystem.GetComponent<TelemetrySystemV2>().UserEntryBoxes.Length; i++)
        {
            if (TelemetrySystem.GetComponent<TelemetrySystemV2>().UserEntryBoxes[i].GetComponent<TMP_InputField>().text == "")
            {
                DataMissing = true;
                Debug.Log(TelemetrySystem.GetComponent<TelemetrySystemV2>().UserEntryBoxes[i] + " Data Missing");

            }
            /*
            Debug.Log("For Loop Going");
            if (TelemetrySystem.GetComponent<TelemetrySystemV2>().DemographicInfo[i] == "")
            {
                DataMissing = true;
                Debug.Log("Data is Missing");
            }
            */

        }
        
        if (DataMissing == false)
        {
            TelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry_Demographic();
            MainMenuCanvas.SetActive(false);
            TestingCanvas.SetActive(false);
            LoadingCanvas.SetActive(true);
            SceneManager.LoadSceneAsync(SceneToLoad); //keep the music playing while loading
        }
        //LoadLevel();
        
    }

    

    public void ReturnToMenu()
    {
        TestingCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);

    }



    //methods for gathering telemetry etc

    public void GetID()
    {
        //TelemetrySystem.GetComponent<TelemetrySystemV2>().DemographicInfo[0] = IdentifierInputBox.GetComponent<TMP_InputField>().text;
    }

    
}
