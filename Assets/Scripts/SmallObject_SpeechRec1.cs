using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using TMPro;


public class SmallObject_SpeechRec1 : MonoBehaviour
{
    public GameObject PlayerController; //reference to get the player controller
    public AudioSource AS; //reference for the audiosource on the player controller

    public bool InArtefactArea = false; //bool for checking if the player is in the target area
    public GameObject other; //reference for the artifact's interact riing gotten from the player, named other because im copying and pasting my oringal small object speech rec script over

    public bool GetKeywords = false;
    public string[] LastKeywords;

    public bool SliderObject = false;
    public GameObject Artefact; //reference for the given artefact
    public GameObject LastArtefact;
    public GameObject Temp;
    public string[] Keywords; //list of keywords that the player can say
    public AudioClip[] GatheredInfo; //list of relevant audioclips
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords

    public TMP_Text ActiveCommand_Notebook;
    public TMP_Text ActiveInfo_Notebook;


    // Start is called before the first frame update
    

    void Start()
    {
        keywordRecogniser.Dispose();
        actions.Remove(Keywords[0]);
        actions.Remove(Keywords[1]);
        actions.Remove(Keywords[2]);
        actions.Remove(Keywords[3]);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController == null)
        {
            PlayerController = GameObject.FindGameObjectWithTag("Player");
            AS = PlayerController.GetComponent<AudioSource>(); //find the audio source on the player controller

        }
        if (PlayerController.GetComponent<PlayerExhibitObserver>().InteractRing == null && PlayerController != null)
        {
            /*
            Debug.Log("User not in area");
            InArtefactArea = false;
            other = null;
            SliderObject = false;
            Artefact = null;
            GatheredInfo = null;
            actions.Remove(Keywords[0]);
            actions.Remove(Keywords[1]);
            actions.Remove(Keywords[2]);
            actions.Remove(Keywords[3]);
            GetKeywords = false;
            Keywords = null;
            keywordRecogniser.Dispose();
            keywordRecogniser.Stop();
            */

        }

        else
        {
            Debug.Log("User in area");
            InArtefactArea = true;
            other = PlayerController.GetComponent<PlayerExhibitObserver>().InteractRing;
            for (int i = 0; i < other.transform.parent.childCount; i++) //for each of the sibling gameobjects of the interact ring
            {
                if (keywordRecogniser != null) //resets the keyword recogniser if it is not already null
                {
                    keywordRecogniser.Dispose();
                }

                if (other.gameObject.transform.parent.GetChild(i).gameObject.tag == "Artefact")

                {
                    LastArtefact = Artefact;
                    Artefact = other.gameObject.transform.parent.GetChild(i).gameObject; //assigns the artefact object
                    GatheredInfo = Artefact.GetComponent<AssignInformation>().AudioInfo; //gets the audio clips from the assign info script on the object

                    

                    Keywords = Artefact.GetComponent<AssignInformation>().keywords; // gets the keywords from the assing info script on the object
                    
                    Debug.Log("New Keywords added");
                    actions.Add(Keywords[0], PointOfInterest1); //creates the commands from the keywords
                    actions.Add(Keywords[1], PointOfInterest2);
                    actions.Add(Keywords[2], PointOfInterest3);
                    actions.Add(Keywords[3], PointOfInterest4);
                    Debug.Log("Keyword Recogniser started");
                    keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
                    keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
                    keywordRecogniser.Start();




                }
                


            }

          
            
            
            

        }

        
    }

    public void KeywordsFucntion()
    {
        

        


        //Debug.Log("Break Two");


        

        
        

    }
    public void PointOfInterest1() //plays the releva
    {
        if (AS.isPlaying == false)
        {
            AS.PlayOneShot(GatheredInfo[0]);
            ActiveCommand_Notebook.text = Keywords[0];
            ActiveInfo_Notebook.text = Artefact.GetComponent<AssignInformation>().RelevantInfo[0];
        }


    }
    public void PointOfInterest2()
    {
        if (AS.isPlaying == false)
        {
            AS.PlayOneShot(GatheredInfo[1]);
            ActiveCommand_Notebook.text = Keywords[1];
            ActiveInfo_Notebook.text = Artefact.GetComponent<AssignInformation>().RelevantInfo[1];
        }


    }
    public void PointOfInterest3()
    {
        if (AS.isPlaying == false)
        {
            AS.PlayOneShot(GatheredInfo[2]);
            ActiveCommand_Notebook.text = Keywords[2];
            ActiveInfo_Notebook.text = Artefact.GetComponent<AssignInformation>().RelevantInfo[2];
        }


    }
    public void PointOfInterest4()
    {
        if (AS.isPlaying == false)
        {
            AS.PlayOneShot(GatheredInfo[3]);
            ActiveCommand_Notebook.text = Keywords[3];
            ActiveInfo_Notebook.text = Artefact.GetComponent<AssignInformation>().RelevantInfo[3];
        }


    }
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }


}


    
    

    

    

