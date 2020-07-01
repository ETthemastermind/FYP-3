using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;
using Valve.VR;
using Leap.Unity.Attributes;


public class DioramaEnterGesture : MonoBehaviour
{
    public GameObject DioramaDisplay;
    public GameObject DioramaStand;
    public bool InArea = false;

    public GameObject RightPalm;  
    public GameObject LeftPalm;
    public LineRenderer LR;
    public float PalmDistance;
    public float MaxHandDistance;
    public float Timer;
    public float ElapsedTime;
    public Material Red;
    public Material Orange;
    public Material Green;

    public bool GestureActive = false;

    //public GameObject SOSR;

    //public GameObject SOSRObject;
    public int LevelToLoad;
    public string LevelName;

    //public GameObject DebugSphere;

    public Animator animator;

    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
                                                                                                // Start is called before the first frame update

    public bool TelemetryPush1;      //set of variables to stop the data being pushed per frame;
    public bool TelemetryPush2;
    public bool TelemetryPush3;
    public bool TelemetryPush4;
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>(); //gets the line renderer component

        /*
        actions.Add("Enter", OnFadeComplete);
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
        */
    }

    // Update is called once per frame
    void Update()
    {
        PalmDistance = Vector3.Distance(RightPalm.transform.position, LeftPalm.transform.position); // Finds the distance between left and right palm
        


        if (InArea == true)
        {

            if (GestureActive == true) // if diorma hand gesture is true
            {

                Debug.Log("Do Diorama Things");
                LR.enabled = true; //turn on line renderer 
                LR.SetPosition(0, RightPalm.transform.position); //set positions 1 and 2 of the line renderer to the palms.
                LR.SetPosition(1, LeftPalm.transform.position);

                
                
                

            }
            if (PalmDistance >= 0 && PalmDistance <= (MaxHandDistance / 3) && GestureActive == true)
            {

                LR.material = Red; //When hands get put together, should be red. acts as a sort of loading bar.
                ElapsedTime = 0f;
                //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

                
                if (TelemetryPush2 == false)
                {
                    DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR+ Diorama Gesture - Red Line Renderer");
                    TelemetryPush2 = true;
                    TelemetryPush3 = false;
                    TelemetryPush4 = false;
                }
                

            }
            else if (PalmDistance >= (MaxHandDistance / 3) && (PalmDistance <= (MaxHandDistance / 3) * 2) && GestureActive == true)
            {

                LR.material = Orange;
                ElapsedTime = 0f;
                //DebugSphere.GetComponent<Renderer>().material.color = Color.white;
                
                if (TelemetryPush3 == false)
                {
                    DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR+ Diorama Gesture - Orange Line Renderer");
                    TelemetryPush3 = true;

                    TelemetryPush2 = false;
                    TelemetryPush4 = false;
                }
                

            }
            else if (PalmDistance >= (MaxHandDistance / 3) * 2 && GestureActive == true)
            {
                Debug.Log("Max Distance Reached");
                LR.material = Green;

                
                if (TelemetryPush4 == false)
                {
                    DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR+ Diorama Gesture - Green Line Renderer");
                    TelemetryPush4 = true;
                    TelemetryPush2 = false;
                    TelemetryPush3 = false;

                }
                
                
                if (ElapsedTime <= Timer) //hold the green position for a few seconds
                {
                    ElapsedTime += Time.deltaTime;

                }
                else if (ElapsedTime >= Timer)
                {
                    //DebugSphere.GetComponent<Renderer>().material.color = Color.red;
                    //FadeToLevel(2);
                    DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR Diorama Enter");
                    DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("Exhibit Left");
                    TelemetryPush1 = false;
                    TelemetryPush2 = false;
                    TelemetryPush3 = false;
                    TelemetryPush4 = false;

                    DioramaStand.GetComponent<LoadLevel>().OpenScene();

                }

                if (GestureActive == false)
                {
                    LR.enabled = false;
                }//turns off the line renderer when gesture is inactive, 
            
                

            }

        }
       
        
    }

    public void DioramaGestureActive() //using detectors on the gesture controller, this activates when both hands are facing forwards with open palms 
    {
        Debug.Log("Gesture Active");
        
        
        if (PalmDistance <= 0.5f) //if the the user's hands are close together, activates this bool to enable the rest of the script to work 
        {
            GestureActive = true;
            if (TelemetryPush1 == false)
            {
                DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR+ Diorama Gesture Active");
                TelemetryPush1 = true;

                TelemetryPush2 = false;
                TelemetryPush3 = false;
                TelemetryPush4 = false;
            }

        }
        
        

    }

    public void DioramaGestureInactive()
    {
        Debug.Log("Gesture Inactive");
        DioramaStand.transform.parent.GetComponentInChildren<DioramaExhibitTelemetryV2>().PushData("VR Diorama Gesture Cancelled");
        TelemetryPush1 = false;
        TelemetryPush2 = false;
        TelemetryPush3 = false;
        TelemetryPush4 = false;
        GestureActive = false;
        //DebugSphere.GetComponent<Renderer>().material.color = Color.white;


    }
    /*
    public void FadeToLevel(int LevelIndex)
    {
        //animator.SetTrigger("FadeOut");
        OnFadeComplete();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
        //LevelToLoad = 0;
    }
    */
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "InteractRing" && other.gameObject.transform.parent.tag == "DioramaDisplay")
        {

            InArea = true;
            DioramaDisplay = other.gameObject.transform.parent.gameObject;
            for (int i = 0; i < DioramaDisplay.transform.childCount; i++)
            {
                if (DioramaDisplay.transform.GetChild(i).gameObject.tag == "Artefact")
                {
                    DioramaStand = DioramaDisplay.transform.GetChild(i).gameObject;
                    LevelToLoad = DioramaStand.GetComponent<Diorama_Teleport>().TargetSceneIndex; //get the scene index from the display stand
                    

                }

            }
        }

        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        InArea = false;
        DioramaDisplay = null;
        DioramaStand = null;
        LevelToLoad = 0;
    }

    public void DebuggingDE()
    {
        Debug.Log("DE - Hands Open");
    }

    
}
