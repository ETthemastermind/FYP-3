using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveModality : MonoBehaviour //easy way to pick which version
{
    public bool GamepadModality = false; //standard mode
    public bool EnhancedModality = false; // Speech rec, Vr, Leap

    public GameObject Gamepad_Player; //Gamepad player
    public GameObject Enhanced_Player; // Player with speech rec, vr and leap 
    // Start is called before the first frame update
    void Awake() //on awake, turns on the right player depending on the bool.
    {
        if (GamepadModality == true)
        {
            Gamepad_Player.SetActive(true);
            Enhanced_Player.SetActive(false);
        }

        else if (Enhanced_Player == true)
        {
            Gamepad_Player.SetActive(false);
            Enhanced_Player.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
