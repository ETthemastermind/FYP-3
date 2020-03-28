using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIActive : MonoBehaviour
{
    public GameObject Gamepad_Player;
    public GameObject VR_SR_Player;
    public GameObject VR_SR_LM_Player;

    public GameObject ModalityController;
    // Start is called before the first frame update
    void Start()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");

        if (ModalityController.GetComponent<ActiveModality>().GamepadModality == true)
        {
            Gamepad_Player.SetActive(true);
            VR_SR_Player.SetActive(false);
            VR_SR_LM_Player.SetActive(false);

        }

        else if (ModalityController.GetComponent<ActiveModality>().SpeechRecVirtualRealityModality == true)
        {
            Gamepad_Player.SetActive(false);
            VR_SR_Player.SetActive(true);
            VR_SR_LM_Player.SetActive(false);

        }

        else if (ModalityController.GetComponent<ActiveModality>().SpeechRecVirtualRealityLeapMotionModality == true)
        {
            Gamepad_Player.SetActive(false);
            VR_SR_Player.SetActive(false);
            VR_SR_LM_Player.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
