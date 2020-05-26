using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCorrectPlayer : MonoBehaviour
{
    public GameObject GamepadPlayer; //references for the players versions
    public GameObject VRSRPlayer;
    public GameObject VRLMSRPlayer;

    public GameObject ModalityController;
    // Start is called before the first frame update
    void Start()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
        if (ModalityController.GetComponent<ModalityController2>().Gamepad_Chosen == true)
        {
            GamepadPlayer.SetActive(true);
            VRSRPlayer.SetActive(false);
            VRLMSRPlayer.SetActive(false);
        }

        else if (ModalityController.GetComponent<ModalityController2>().VRSR_Chosen == true)
        {
            GamepadPlayer.SetActive(false);
            VRSRPlayer.SetActive(true);
            VRLMSRPlayer.SetActive(false);
        }

        else if (ModalityController.GetComponent<ModalityController2>().VRLMSR_Chosen == true)
        {
            GamepadPlayer.SetActive(false);
            VRSRPlayer.SetActive(false);
            VRLMSRPlayer.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
