using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Windows.Speech;
using System.Linq;

public class TeleportCursor : MonoBehaviour
{
    public GameObject TeleportTestCursor; //pink capsule on VR camera, underneath SteamVRObjects on NEW Enhanced Player - VR,SR,LM
    public GameObject Cursor2;
    public GameObject Player;
    public Vector3 Cursor2_Location;
    public Vector3 Cursor2_LocationStart;
   
    

    public float MaxDistance; //maximum distance cursor can go from player
    
    

    public bool _IsPointing; //bool for when the fingertip is pointing
    
    public GameObject TeleportPointGesture; //ref for the object w/ the teleport point gesture script

    

    


    public float CurrentDistance; //distance from cursor to player
    public bool CursorCanMoveForwards = true; //bools that determine if the cursor can still move
    public bool CursorCanMoveBackwards = true;

    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Move Cursor Forwards", MoveCursorForward);  //keywords with the cursor
        actions.Add("Move Cursor Forwards A Little", MoveCursorForward2);
        actions.Add("Move Cursor Forwards A Lot", MoveCursorForward3);

        actions.Add("Move Cursor Backwards", MoveCursorBackwards);
        actions.Add("Move Cursor Backwards A Little", MoveCursorBackwards2);
        actions.Add("Move Cursor Backwards A Lot", MoveCursorBackwards3);
        actions.Add("Reset Cursor", ResetCursor);
        actions.Add("Move", Teleport);
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();

        Cursor2_LocationStart = TeleportTestCursor.transform.position; //gets start location of the cursor

    }
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    // Update is called once per frame
    void Update()
    {   //shows user cursor
        if (_IsPointing == true) //if the user is pointing
        {

            Cursor2.SetActive(true); //activate the cursor
            Cursor2_Location = new Vector3(TeleportTestCursor.transform.position.x, Cursor2.transform.position.y, TeleportTestCursor.transform.position.z); //create new vector3 to place the cursor
            Cursor2.transform.position = Cursor2_Location; //place the cursor, places underneath the test cursor (pink capsule) on the floor 
            



        }
        
        //---------------------------------------limits how far the cursor can move--------------------------------------------///
        CurrentDistance = Vector3.Distance(transform.position, TeleportTestCursor.transform.position);
        if (CurrentDistance > 1.5f)
        {
            CursorCanMoveBackwards = true;

        }

        else
        {
            CursorCanMoveBackwards = false;
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 0.5f;

        }





        if (CurrentDistance < MaxDistance)
        {
            CursorCanMoveForwards = true;

        }

        else
        {
            CursorCanMoveForwards = false;
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;
        }

        //---------------------------------------------Stops the cursor going through walls ----------------------------------------------------// temp disabled

        if (TeleportTestCursor.GetComponent<InWall>().CursorInWall == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;

        }

        
    }


    public void IsPointingGesture()
    {
        _IsPointing = true; //player is pointing
        //StartPosition = FingerTip.transform.position;


    }

    public void IsNotPointingGesture() //player is not pointing
    {
        _IsPointing = false;
    }

    public void Teleport()
    {
        
        TeleportPointGesture.GetComponent<TeleportPointGesture>().Teleport = true; //actiavte teleport bool on teleport point gesture script (on the TeleportPointGesture object under NEW Enhanced player - VR, SR, LM) used to be a thumbs up, but rerouted so that it uses SR
        
    }

    




    

   

    public void MoveCursorForward()  //move cursor forwards
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 1f;
        }
        

    }
    public void MoveCursorForward2() //move cursor forwards a little
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 0.5f;
        }
        

    }

    public void MoveCursorForward3() //move cursor forwards a lot
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 2.5f;
        }
        

    }

    public void MoveCursorBackwards() //move cursor backwards
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 1f;
        }
        

    }
    public void MoveCursorBackwards2() //move cursor backwards a little
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;
        }
        

    }
    public void MoveCursorBackwards3() //move cursor backwards a lot
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 2.5f;
        }
        

    }

    public void ResetCursor() //reset cursor
    {
        TeleportTestCursor.transform.position = Cursor2_LocationStart;
    }


    public void TeleportFadeIn() //Fades VR cam to black
    {
        SteamVR_Fade.Start(Color.black, 0.2f);
        Debug.Log("Fade In");


    }

    public void TeleportFadeOut() //fades VR cam back to being able to see
    {
        SteamVR_Fade.Start(Color.clear, 0.2f);
        Debug.Log("Fade Out");

    }

}
