using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayersNotebook;
    public AudioSource AS;
    private bool AudioPlayed;
    private bool NotebookActive;
    public GameObject NotebookController;
    //Phase 1 variables of the tutorial//
    public bool TriggerPhase1;
    public GameObject CuratorPortrait; //ref for the curator portrait
    public Material CuratorPortraitMat; //ref for the material on the portrait (woman with blurred musuem background
    public GameObject PortraitInteractRing;
    public Color LerpedColour = Color.black; //ref for the lerped color for the emissive, black is no emissive

    public AudioClip HelloThere;
    

    //Phase 2 variables
    public bool TriggerPhase2;
    public GameObject PortraitKeyword1;
    public GameObject Instructions;
    public GameObject PortraitKeyword2;
    public GameObject PortraitKeyword3;
    public GameObject PortraitKeyword4;
    public GameObject SpeechController;
    public string LastWordSaid;
    public string LastWordDefault;

    public AudioClip TellMeAboutThis;
    

    //Phase 3 variables
    public bool TriggerPhase3;
    public GameObject Notebook;
    public Material NotebookMat;
    public GameObject ArtifactInteractRing;

    //phase 4 variables
    public bool TriggerPhase4;
    public AudioClip PickUp;
    public GameObject PickUpController;

    //phase 5 variables
    public bool TriggerPhase5;
    public AudioClip PutDown;

    //phase 6 variables
    public bool TriggerPhase6;
    public AudioClip Guidebook;

    //phase 7 variables
    public bool TriggerPhase7;

    //phase 8 variables
    public bool TriggerPhase8;

    //phase 9 variables
    public bool TriggerPhase9;

    //phase 10 variables
    public bool TriggerPhase10;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayersNotebook = GameObject.FindGameObjectWithTag("Notebook");
        AS = Player.GetComponent<AudioSource>();
        PickUpController = GameObject.FindGameObjectWithTag("PickUpController");
        NotebookController = GameObject.FindGameObjectWithTag("NotebookController");
        PlayersNotebook.SetActive(false);
        NotebookController.SetActive(false);

        CuratorPortraitMat = CuratorPortrait.GetComponent<Renderer>().materials[1]; //finds the correct mat on the portrait 
        NotebookMat = Notebook.GetComponent<Renderer>().materials[0];
        PortraitKeyword1.SetActive(false);
        PortraitKeyword2.SetActive(false);
        PortraitKeyword3.SetActive(false);
        PortraitKeyword4.SetActive(false);

        SpeechController = GameObject.FindGameObjectWithTag("SpeechController");
        LastWordDefault = SpeechController.GetComponent<PortraitSpeechRec>().LastSaidWord;
    }

    // Update is called once per frame
    void Update()

    {




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
            Phase3();
        }
        if (TriggerPhase4 == true)
        {
            Phase4();
        }
        if (TriggerPhase5 == true)
        {
            Phase5();
        }
        if (TriggerPhase6 == true)
        {
            Phase6();
        }

    }

    public void Phase1() //Leading user to portrait, portrait glows until the user steps in the ring
    {
        Debug.Log("Phase 1 tutorial active");

        if (AudioPlayed == false && AS.isPlaying == false) //play instructions if clip is not played and no other clip is playing.
        {
            AS.PlayOneShot(HelloThere);
            AudioPlayed = true;

        }
        

        LerpedColour = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1)); //lerp between black and yellow, gives a nice tutorial glowing effect
        CuratorPortraitMat.SetColor("_EmissionColor", LerpedColour); //sets the glow emissive color of the portrait
        if (PortraitInteractRing.GetComponent<AreaEntered>().PlayerInTrigger == true) //if the player enters the interact ring, trigger phase 2
        {
            TriggerPhase2 = true;
            TriggerPhase1 = false;
            AudioPlayed = false;

        }

    }

    public void Phase2() //introducing the "tell me about this"
    {
        Debug.Log("Phase 2 tutorial active");
        if (AudioPlayed == false && AS.isPlaying == false)
        {
            AS.PlayOneShot(TellMeAboutThis);
            AudioPlayed = true;
        }
        
        string LastWordSaid = SpeechController.GetComponent<PortraitSpeechRec>().LastSaidWord; //gets the last word said from the speech controller
        TriggerPhase1 = false; //deactivates phase one
        CuratorPortraitMat.SetColor("_EmissionColor", Color.black);
       
        PortraitKeyword1.SetActive(true);
        Instructions.SetActive(true);

        //PortraitKeyword1.transform.FindChild[0].GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, 1));
        LastWordSaid = SpeechController.GetComponent<PortraitSpeechRec>().LastSaidWord;
        //Debug.Log(LastWordSaid + "said");
        if (LastWordSaid == LastWordDefault) //checking to see if the user has done as requested, trigger phase 3 if yes
        {
            TriggerPhase3 = false;

        }

        else
        {
            TriggerPhase3 = true;
            AudioPlayed = false;
            TriggerPhase2 = false;

        }
    }

    public void Phase3() //Send them to pick-up artefact, make the artefact glow
    {
        Debug.Log("Phase 3 Tutorial Active");
        NotebookMat.EnableKeyword("_EMISSION");
        LerpedColour = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        NotebookMat.SetColor("_EmissionColor", LerpedColour);

        if (ArtifactInteractRing.GetComponent<AreaEntered>().PlayerInTrigger == true) //if user enters trigger area, trigger phase 4 
        {
            NotebookMat.SetColor("_EmissionColor", Color.black);
            TriggerPhase3 = false;
            TriggerPhase4 = true;

        }
    }

    public void Phase4() // encourage to pick up
    {
        if (AudioPlayed == false && AS.isPlaying == false)
        {
            AS.PlayOneShot(PickUp);
            AudioPlayed = true;
        }

        if (PickUpController.GetComponent<Artefact_Hand_PickUp>().VR_HoldingObject == true) //if user picks up the artefact, trigger phase 5
        {
            TriggerPhase4 = false;
            TriggerPhase5 = true;
            AudioPlayed = false;

        }
        

    }

    public void Phase5() // encourage to put down
    {
        if (AudioPlayed == false && AS.isPlaying == false)
        {
            AS.PlayOneShot(PutDown);
            AudioPlayed = true;
        }

        if (PickUpController.GetComponent<Artefact_Hand_PickUp>().VR_HoldingObject == false) //if user puts down the artefact, trigger phase 5
        {
            TriggerPhase5 = false;
            TriggerPhase6 = true;
            AudioPlayed = false;

        }
    }

    public void Phase6() //Show to request information 
    {
        NotebookController.SetActive(true);
        if (AudioPlayed == false && AS.isPlaying == false)
        {
            AS.PlayOneShot(Guidebook);
            AudioPlayed = true;
        }
    }

    public void Phase7() //send to the slider object
    {


    }

    public void Phase8() //Show how to use slider
    {


    }

    public void Phase9() //send to the Diorama
    {


    }

    public void Phase10() //show how to use Diorama
    {

    } 



}





