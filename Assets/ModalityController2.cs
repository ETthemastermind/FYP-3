using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ModalityController2 : MonoBehaviour
{
    public bool Gamepad_Chosen;
    public bool VRSR_Chosen;
    public bool VRLMSR_Chosen;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamepadModality()
    {
        Gamepad_Chosen = true;
        Debug.Log("Level Loading");
        SceneManager.LoadScene(1);
    }

    public void VRSRModality()
    {
        VRSR_Chosen = true;
        Debug.Log("Level Loading");
        SceneManager.LoadScene(1);
    }

    public void VRSRLMModality()
    {
        VRLMSR_Chosen = true;
        Debug.Log("Level Loading");
        SceneManager.LoadScene(1);
    }
}
