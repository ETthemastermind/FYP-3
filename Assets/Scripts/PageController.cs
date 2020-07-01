using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows.Speech;
using System.Linq;


public class PageController : MonoBehaviour
{
    public GameObject[] Pages; //array of pages
    public int LeftPageNum = 1; //starting page number
    public TMP_Text LeftPageText; // TMP text reference
    public int RightPageNum = 2;
    public TMP_Text RightPageText;

    public int ActivePage = 0; //int reference for the active page


    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords

    // Start is called before the first frame update
    void Start()
    {
        LeftPageText.text = LeftPageNum.ToString(); //converts starting page int to strings
        RightPageText.text = RightPageNum.ToString();


        actions.Add("Next Page", IncrementPageSR); // adds voice commands to control page turning etc
        actions.Add("Last Page", DecrementPageSR);

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

    public void IncrementPage()  // function to increment page
    {
        Pages[ActivePage].SetActive(false); //turns the current page off
        ActivePage += 1; //increments the active page
        if (ActivePage > Pages.Length - 1) // if the active page goes beyond the number of possible pages
        {
            ActivePage = Pages.Length - 1; //sets the active page to the last page

        }
        else
        {
            LeftPageNum += 2; //increments the page numbers
            RightPageNum += 2;

            LeftPageText.text = LeftPageNum.ToString();
            RightPageText.text = RightPageNum.ToString();
        }

        Pages[ActivePage].SetActive(true); //turns the new current page on
        


    }

    public void DecrementPage() //basically the opposite of the increment function
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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("Page turned using SR (Decrement)");



    }

    //next set of functions takes the user to requested pages

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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("SR - Go To Commands Page");
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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("SR - Go To Portraits Page");

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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("SR - Go To Artefact Page");

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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("SR - Go To Slider Page");

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
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("SR - Go To Diorama Page");


    }

    public void IncrementPageSR()
    {
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("Page turned using SR (Increment)");
        IncrementPage();
    }

    public void DecrementPageSR()
    {
        gameObject.GetComponent<NotebookTelemetrySystem>().PushData("Page turned using SR (Decrement)");
        DecrementPage();

    }

}
