using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControllerStandard : MonoBehaviour
{
    public GameObject ModalityController;
    //phase 1 variables//

    
    // Start is called before the first frame update
    void Start()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
        if (ModalityController.GetComponent<ModalityController2>().Gamepad_Chosen == true)
        {

        }

        else

        {
            this.gameObject.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
