using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveModality : MonoBehaviour
{
    public bool GamepadModality = false;
    public bool EnhancedModality = false;

    public GameObject Gamepad_Player;
    public GameObject Enhanced_Player;
    // Start is called before the first frame update
    void Awake()
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
