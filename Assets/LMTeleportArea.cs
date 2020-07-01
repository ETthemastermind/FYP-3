using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMTeleportArea : MonoBehaviour
{
    public GameObject ModalityController;
    // Start is called before the first frame update
    void Start()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
        if (ModalityController.GetComponent<ModalityController2>().VRLMSR_Chosen != true)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
