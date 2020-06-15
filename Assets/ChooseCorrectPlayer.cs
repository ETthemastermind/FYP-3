using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ChooseCorrectPlayer : MonoBehaviour
{
    public GameObject GamepadPlayer; //references for the players versions
    public GameObject VRSRPlayer;
    public GameObject VRLMSRPlayer;

    public bool GamepadPlayerOnDebug;
    public bool VRSRPlayerOnDebug;
    public bool VRSRLMPlayerOnDebug;
    

    

    public GameObject ModalityController;
    // Start is called before the first frame update
    void Awake()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
        if (ModalityController.GetComponent<ModalityController2>().Gamepad_Chosen == true || GamepadPlayerOnDebug == true)
        {
            GamepadPlayer.SetActive(true);
            VRSRPlayer.SetActive(false);
            VRLMSRPlayer.SetActive(false);

            XRSettings.enabled = false;



        }

        else if (ModalityController.GetComponent<ModalityController2>().VRSR_Chosen == true || VRSRPlayerOnDebug == true)
        {
            GamepadPlayer.SetActive(false);
            VRSRPlayer.SetActive(true);
            VRLMSRPlayer.SetActive(false);
            XRSettings.enabled = true;


            GameObject.FindGameObjectWithTag("Player").SetActive(true);
        }

        else if (ModalityController.GetComponent<ModalityController2>().VRLMSR_Chosen == true || VRSRLMPlayerOnDebug == true)
        {
            GamepadPlayer.SetActive(false);
            VRSRPlayer.SetActive(false);
            VRLMSRPlayer.SetActive(true);
            XRSettings.enabled = true;

        }

       




       
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
