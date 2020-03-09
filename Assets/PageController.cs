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
        }

        Pages[ActivePage].SetActive(true);
        /*
        ActivePage += 1;
        if (ActivePage != Pages.Length)
        {
            LeftPageNum += 2;
            RightPageNum += 2;

            LeftPageText.text = LeftPageNum.ToString();
            RightPageText.text = RightPageNum.ToString();
            //Pages[ActivePage - 1].SetActive(false);
            
            if (ActivePage == Pages.Length)
            {
                Debug.Log("Page Limit Reached");

            }
            else
            {
                
                Pages[ActivePage].SetActive(true);
            }

        }*/
        
       

    }

    public void DecrementPage()
    {
        Pages[ActivePage].SetActive(false);
        ActivePage -= 1;
        if (ActivePage < 0)
        {
            ActivePage = 0;
            
        }
        Pages[ActivePage].SetActive(true);
      
        /*
        if (ActivePage == 0)
        {
            LeftPageNum -= 2;
            RightPageNum -= 2;

            if (LeftPageNum < 1)
            {
                LeftPageNum = 1;


            }

            if (RightPageNum < 2)
            {
                RightPageNum = 2;

            }


            if (ActivePage == 0)
            {

            }

            else
            {
                LeftPageText.text = LeftPageNum.ToString();
                RightPageText.text = RightPageNum.ToString();

                Pages[ActivePage].SetActive(false);
                ActivePage -= 1;
                Pages[ActivePage].SetActive(true);

            }

        }
        
        */

    }
}
