using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGestureInfo : MonoBehaviour
{
    public GameObject InteractRing;
    public GameObject HandGesture;
    public GameObject SpeechGesture;
    public GameObject ModalityController;

    public bool CorrectModality = false;
    // Start is called before the first frame update
    void Start()
    {
        ModalityController = GameObject.FindGameObjectWithTag("ModalityController");
        if (ModalityController.GetComponent<ActiveModality>().EnhancedModality == true)
        {
            CorrectModality = true;

        }

        HandGesture.SetActive(false);
        SpeechGesture.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractRing.GetComponent<AreaEntered>().PlayerInTrigger == true && CorrectModality == true)
        {
            HandGesture.SetActive(true);
            SpeechGesture.SetActive(true);
        }
        else if (InteractRing.GetComponent<AreaEntered>().PlayerInTrigger == false && CorrectModality == true)
        {
            HandGesture.SetActive(false);
            SpeechGesture.SetActive(false);
        }
    }
}
