using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows.Speech;
using System.Linq;


public class PageController : MonoBehaviour
{
    public GameObject[] Pages;
    public int LeftPageNum = 1;
    public TMP_Text LeftPageText;
    public int RightPageNum = 2;
    public TMP_Text RightPageText;

    public int ActivePage = 0;


    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords

    // Start is called before the first frame update
    void Start()
    {
        LeftPageText.text = LeftPageNum.ToString();
        RightPageText.text = RightPageNum.ToString();


        actions.Add("Next Page", IncrementPage);
        actions.Add("Last Page", DecrementPage);

        actions.Add("Go to Commands Page", GoToCommands);
        actions.Add("Go to Portrait Page", GoToPortrait);
        actions.Add("Go to Artefact Page", GoToArtefact);
        actions.Add("Go to Slider Page", GoToSlider);
        actions.Add("Go to Diorama Page", GoToDiorama);



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

    public void IncrementPage()
    {
        Pages[ActivePage].SetActive(false);
        ActivePage += 1;
        if (ActivePage > Pages.Length - 1)
        {
            ActivePage = Pages.Length - 1;

        }
        else
        {
            LeftPageNum += 2;
            RightPageNum += 2;

            LeftPageText.text = LeftPageNum.ToString();
            RightPageText.text = RightPageNum.ToString();
        }

        Pages[ActivePage].SetActive(true);


    }

    public void DecrementPage()
    {
        Pages[ActivePage].SetActive(false);
        ActivePage -= 1;
        if (ActivePage < 0)
        {
            ActivePage = 0;

        }

        else
        {
            LeftPageNum -= 2;
            RightPageNum -= 2;

            LeftPageText.text = LeftPageNum.ToString();
            RightPageText.text = RightPageNum.ToString();

        }
        Pages[ActivePage].SetActive(true);

        

    }

    public void GoToCommands()
    {
        Pages[ActivePage].SetActive(false);
        for (int i = 0; i != Pages.Length; i++)
        {
            if (Pages[i].gameObject.name == "Command Pages")
            {
                Pages[i].SetActive(true);
                ActivePage = i;

            }

        }
    }

    public void GoToPortrait()
    {
        Pages[ActivePage].SetActive(false);
        for (int i = 0; i != Pages.Length; i++)
        {
            if (Pages[i].gameObject.name == "Portrait Gestures")
            {
                Pages[i].SetActive(true);
                ActivePage = i;

            }

        }

    }

    public void GoToArtefact()
    {
        Pages[ActivePage].SetActive(false);
        for (int i = 0; i != Pages.Length; i++)
        {
            if (Pages[i].gameObject.name == "Artefact Display")
            {
                Pages[i].SetActive(true);
                ActivePage = i;

            }

        }

    }

    public void GoToSlider()
    {
        Pages[ActivePage].SetActive(false);
        for (int i = 0; i != Pages.Length; i++)
        {
            if (Pages[i].gameObject.name == "Sliding Display")
            {
                Pages[i].SetActive(true);
                ActivePage = i;

            }

        }

    }

    public void GoToDiorama()
    {
        Pages[ActivePage].SetActive(false);
        for (int i = 0; i != Pages.Length; i++)
        {
            if (Pages[i].gameObject.name == "Diorama Gestures")
            {
                Pages[i].SetActive(true);
                ActivePage = i;

            }

        }


    }

}
