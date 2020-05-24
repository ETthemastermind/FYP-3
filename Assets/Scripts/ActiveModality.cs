using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActiveModality : MonoBehaviour //easy way to pick which version
{
    public bool GamepadModality = false; //standard mode
    public bool SpeechRecVirtualRealityLeapMotionModality = false; // Speech rec, Vr, Leap
    public bool SpeechRecVirtualRealityModality = false; // Speech rec, Vr, Leap
    
    
    public GameObject Gamepad_Player; //Gamepad player
    public GameObject SpeechRecVirtualRealityLeapMotion_Player; // Player with speech rec, vr and leap 
    public GameObject SpeechRecVirtualReality_Player; // Player with speech rec, vr
    
    


    // Start is called before the first frame update
    void Awake() //on awake, turns on the right player depending on the bool.
    {
        if (GamepadModality == true)
        {
            GamePadOn();
        }

        else if (SpeechRecVirtualRealityModality == true)
        {
            VR_SR_On();

        }

        else if (SpeechRecVirtualRealityLeapMotionModality == true)
        {
            VR_SR_LM_On();

        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamePadOn()
    {
        Gamepad_Player.SetActive(true);
        SpeechRecVirtualReality_Player.SetActive(false);
        SpeechRecVirtualRealityLeapMotion_Player.SetActive(false);
        

    }
    public void VR_SR_On()
    {
        Gamepad_Player.SetActive(false);
        SpeechRecVirtualReality_Player.SetActive(true);
        SpeechRecVirtualRealityLeapMotion_Player.SetActive(false);



    }
    public void VR_SR_LM_On()
    {
        Gamepad_Player.SetActive(false);
        SpeechRecVirtualReality_Player.SetActive(false);
        SpeechRecVirtualRealityLeapMotion_Player.SetActive(true);


    }
}
