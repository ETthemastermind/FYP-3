using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SliderObjectSpeech : MonoBehaviour
{
    public bool ActiveSlider = false;
    public GameObject SliderObject;
    //public GameObject RightCycle_Object;
    
    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Cycle Right", CycleRight);
        actions.Add("Cycle Left", CycleLeft);

        
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractRing")
        {
            if (other.gameObject.transform.parent.tag == "SliderArtefact")
            {
                SliderObject = other.gameObject.transform.parent.gameObject;
                ActiveSlider = true;

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractRing" && SliderObject != null)
        {
            SliderObject = null;
            ActiveSlider = false;
        }
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void CycleRight()
    {
        if (ActiveSlider == true)
        {
            Debug.Log("Cycling Right");
            SliderObject.GetComponent<SliderObject>().IncrementDisplay();
        }
        

    }

    private void CycleLeft()
    {
        if (ActiveSlider == true)
        {
            Debug.Log("Cycling Left");
            SliderObject.GetComponent<SliderObject>().DecrementDisplay();
        }
        
    }
}
