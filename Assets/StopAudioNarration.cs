using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class StopAudioNarration : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords

    public GameObject Player; //reference to the player character
    public AudioSource AS;
    public GameObject Notebook;
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
        actions.Add("Stop", StopAudio);


        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);

        actions[speech.text].Invoke();


    }

    public void StopAudio()
    {
        
        if (AS.isPlaying == true)
        {
            Notebook.GetComponent<NotebookTelemetrySystem>().PushData("Stop Audio Used", System.DateTime.Now.ToLongTimeString(), "N/A", "N/A");
            AS.Stop();
            
        }

    }
}
