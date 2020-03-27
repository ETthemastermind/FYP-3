using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalityController : MonoBehaviour
{
    public bool GamepadModality = false; //standard mode
    public bool SpeechRecVirtualRealityLeapMotionModality = false; // Speech rec, Vr, Leap
    public bool SpeechRecVirtualRealityModality = false; // Speech rec, Vr, Leap

    public bool Test;

    public GameObject Gamepad_Player; //Gamepad player
    public GameObject SpeechRecVirtualRealityLeapMotion_Player; // Player with speech rec, vr and leap 
    public GameObject SpeechRecVirtualReality_Player; // Player with speech rec, vr
    // Start is called before the first frame update
    void Awake() //on awake, turns on the right player depending on the bool.
    {
        if (GamepadModality == true)
        {
            Gamepad_Player.SetActive(true);
            SpeechRecVirtualRealityLeapMotion_Player.SetActive(false);
            SpeechRecVirtualReality_Player.SetActive(false);
        }

        else if (SpeechRecVirtualRealityLeapMotionModality == true)
        {
            Gamepad_Player.SetActive(false);
            SpeechRecVirtualRealityLeapMotion_Player.SetActive(true);
            SpeechRecVirtualReality_Player.SetActive(false);

        }

        else if (SpeechRecVirtualRealityModality == true)
        {
            Gamepad_Player.SetActive(false);
            SpeechRecVirtualRealityLeapMotion_Player.SetActive(false);
            SpeechRecVirtualReality_Player.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
