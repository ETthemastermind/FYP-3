using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ModalityController2 : MonoBehaviour
{
    public bool Gamepad_Chosen;
    public bool VRSR_Chosen;
    public bool VRLMSR_Chosen;

    public bool TestingModeActivated;

    public int SceneToLoad;
    public GameObject IdentifierInputBox;
    public GameObject NoModalitySelected;

    //refs to canvas
    public GameObject MainMenuCanvas;
    public GameObject TestingCanvas;
    public GameObject LoadingCanvas;


    //Testing Variables
    public string UserIdentifier;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); //keeps the modality controller persistent between scenes
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

    }

    public void VRSRModality()
    {
        Gamepad_Chosen = false; //activates the boolean so that the controllers in the museum scenes reference the correct controller
        VRSR_Chosen = true;
        VRLMSR_Chosen = false;
        NoModalitySelected.SetActive(false);
    }

    public void VRSRLMModality()
    {
        Gamepad_Chosen = false; //activates the boolean so that the controllers in the museum scenes reference the correct controller
        VRSR_Chosen = false;
        VRLMSR_Chosen = true;
        NoModalitySelected.SetActive(false);

    }

    public void LoadLevel()
    {
        if (Gamepad_Chosen == false && VRSR_Chosen == false && VRLMSR_Chosen == false) //check to see if the user has chosen a modality
        {
            NoModalitySelected.SetActive(true); //show error message
            MainMenuCanvas.SetActive(false);
            TestingCanvas.SetActive(false);
            LoadingCanvas.SetActive(true);


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

        if (TestingModeActivated == false)
        {
            LoadLevel();
        }
        else if (TestingModeActivated == true)
        {
            Debug.Log("Turn Main Menu Canvas Off");
            MainMenuCanvas.SetActive(false);
            TestingCanvas.SetActive(true);

        }
    }

    public void BeginTest()
    {
        Debug.Log("Begin Testing");
        if (UserIdentifier == "")
        {
            
        }
        else
        {
            LoadLevel();
        }
    }

    public void GetUserID() //gets a user ID;
    {
        Debug.Log("User ID Entered"); //prints to console when the value is changed
        UserIdentifier = IdentifierInputBox.GetComponent<TMP_InputField>().text;
    }

    public void ReturnToMenu()
    {
        TestingCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);

    }
}
