using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TutorialController : MonoBehaviour
{
    //Phase 1 variables of the tutorial//
    public bool TriggerPhase1;
    public GameObject CuratorPortrait; //ref for the curator portrait
    public Material CuratorPortraitMat; //ref for the material on the portrait (woman with blurred musuem background
    public GameObject InteractRing;
    public Color LerpedColour = Color.black; //ref for the lerped color for the emissive, black is no emissive

    //Phase 2 variables
    public bool TriggerPhase2;
    public GameObject PortraitKeyword1;
    public GameObject Instructions;
    public GameObject PortraitKeyword2;
    public GameObject PortraitKeyword3;
    public GameObject PortraitKeyword4;
    public GameObject SpeechController;
    public string LastWordSaid;

    public bool TriggerPhase3;

    // Start is called before the first frame update
    void Start()
    {
        CuratorPortraitMat = CuratorPortrait.GetComponent<Renderer>().materials[1]; //finds the correct mat on the portrait 
        PortraitKeyword1.SetActive(false);
        PortraitKeyword2.SetActive(false);
        PortraitKeyword3.SetActive(false);
        PortraitKeyword4.SetActive(false);

        SpeechController = GameObject.FindGameObjectWithTag("SpeechController");
    }

    // Update is called once per frame
    void Update()

    {
        //LastWordSaid = SpeechController.GetComponent<PortraitSpeechRec>().LastSaidWord;
        if (LastWordSaid == "Test")
        {
            TriggerPhase3 = true;
        }


        if (TriggerPhase1 == true) //for now, using booleans to trigger
        {
            Phase1(); //run phase 1
        }

        if (TriggerPhase2 == true)
        {
            Phase2();
        }
        if (TriggerPhase3 == true)
        {

        }
        
    }

    public void Phase1()
    {
        Debug.Log("Phase 1 tutorial active");
        LerpedColour = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1)); //lerp between black and yellow, gives a nice tutorial glowing effect
        CuratorPortraitMat.SetColor("_EmissionColor", LerpedColour); //sets the emissive color of the portrait
        if (InteractRing.GetComponent<AreaEntered>().PlayerInTrigger == true) //if the player enters the interact ring
        {
            TriggerPhase2 = true;
            TriggerPhase1 = false;
            
        }

    }

    public void Phase2()
    {
        LastWordSaid = SpeechController.GetComponent<PortraitSpeechRec>().LastSaidWord;
        TriggerPhase1 = false; //deactivates phase one
        CuratorPortraitMat.SetColor("_EmissionColor", Color.black);
        Debug.Log("Phase 2 tutorial active");
        PortraitKeyword1.SetActive(true);
        Instructions.SetActive(true);

        //PortraitKeyword1.transform.FindChild[0].GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, 1));
        if (LastWordSaid == null)
        {
            TriggerPhase3 = true;
        }
        
    }

    public void Phase3()
    {


    }
}
