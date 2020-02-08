using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class PortraitSpeechRec : MonoBehaviour
{
    public GameObject PointingGesture;
    public GameObject PlayerController;
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
    public GameObject KeywordAskedAbout;
    public AudioClip RequestedInfo;

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Tell Me About This", TellAbout);
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    // Update is called once per frame
    void Update()
    {
        KeywordAskedAbout = PointingGesture.gameObject.GetComponent<PointingGesture>().KeywordObject.gameObject;
        RequestedInfo = KeywordAskedAbout.GetComponent<AudioInfo>().Information;



    }

    public void TellAbout()
    {
        PlayerController.GetComponent<AudioSource>().PlayOneShot(RequestedInfo);
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }
}
