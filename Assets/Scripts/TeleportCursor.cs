using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Windows.Speech;
using System.Linq;

public class TeleportCursor : MonoBehaviour
{
    public GameObject TeleportTestCursor;
    public GameObject Cursor2;

    public Vector3 Cursor2_Location;
    public Vector3 Cursor2_LocationStart;
    public bool MoveForward;
    public bool MoveBackward;
    public float Speed = 5f;

    public float MaxDistance;
    public Vector3 CurrentPosition;
    public Vector3 StartPosition;

    public bool _IsPointing;
    public GameObject FingerTip;
    public GameObject TeleportPointGesture;

    public float Deadzone;

    public bool MoveForwards;
    public bool MoveBackwards;


    public float CurrentDistance;
    public bool CursorCanMoveForwards = true;
    public bool CursorCanMoveBackwards = true;

    private KeywordRecognizer keywordRecogniser; //sets up speech rec
    public Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>(); //dictionairy of keywords
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Move Cursor Forwards", MoveCursorForward);
        actions.Add("Move Cursor Forwards A Little", MoveCursorForward2);
        actions.Add("Move Cursor Forwards A Lot", MoveCursorForward3);

        actions.Add("Move Cursor Backwards", MoveCursorBackwards);
        actions.Add("Move Cursor Backwards A Little", MoveCursorBackwards2);
        actions.Add("Move Cursor Backwards A Lot", MoveCursorBackwards3);
        actions.Add("Reset Cursor", ResetCursor);
        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray()); //activates the speech rec
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();

        Cursor2_LocationStart = TeleportTestCursor.transform.position;

    }
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    // Update is called once per frame
    void Update()
    {   //---------------------------------------limits how far the cursor can move--------------------------------------------///
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





        if (CurrentDistance < 6.5f)
        {
            CursorCanMoveForwards = true;

        }

        else
        {
            CursorCanMoveForwards = false;
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;
        }

        //---------------------------------------------Stops the cursor going through walls ----------------------------------------------------//

        if (TeleportTestCursor.GetComponent<InWall>().CursorInWall == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;

        }










//--------------------------------------------------------------------------------------------------------------------------------------//


        if (MoveForwards == true)
        {
            //TeleportTestCursor.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 1f;
            MoveForwards = false;
        }

        else if (MoveBackwards == true)
        {
            //TeleportTestCursor.transform.Translate(Vector3.back * Speed * Time.deltaTime);
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 1f;
            MoveBackwards = false;

        }
        
        if (_IsPointing == true)
        {

            Cursor2.SetActive(true);
            Cursor2_Location = new Vector3(TeleportTestCursor.transform.position.x, Cursor2.transform.position.y, TeleportTestCursor.transform.position.z);
            Cursor2.transform.position = Cursor2_Location;
            /*
                        CurrentPosition = FingerTip.transform.position;
                        if (Vector3.Distance(StartPosition, CurrentPosition) > Deadzone)
                        {
                            Cursor2.GetComponent<Renderer>().material.color = Color.yellow;




                        }



                    }

                    else
                    {
                        //cursor2.SetActive(false);
                        Cursor2.transform.position = Cursor2_Location;
                    }
             */

            

        }
      

        
    }

    public void TeleportFadeIn()
    {
        SteamVR_Fade.Start(Color.black, 0.2f);
        Debug.Log("Fade In");
        

    }

    public void TeleportFadeOut()
    {
        SteamVR_Fade.Start(Color.clear, 0.2f);
        Debug.Log("Fade Out");

    }


    public void IsPointingGesture()
    {
        _IsPointing = true;
        StartPosition = FingerTip.transform.position;


    }

    public void IsNotPointingGesture()
    {
        _IsPointing = false;
    }

    public void ThumbsUp()
    {
        Cursor2.GetComponent<Renderer>().material.color = Color.green;
        TeleportPointGesture.GetComponent<TeleportPointGesture>().Teleport = true;
    }

    public void ThumbsDown()
    {
        Cursor2.GetComponent<Renderer>().material.color = Color.red;

    }





    /*
       if (MoveForward == true && Vector3.Distance(transform.position, TeleportTestCursor.transform.position) < MaxDistance)
       {
           TeleportTestCursor.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
       }

       if (MoveBackward == true && Vector3.Distance(transform.position, TeleportTestCursor.transform.position) > 3)
       {

           TeleportTestCursor.transform.Translate(Vector3.back * Speed * Time.deltaTime);
       }
       */

    public void TempMoveForward_On()
    {
        MoveForwards = true;
        MoveBackwards = false;
        Debug.Log("Debug for Moving Forwards");
        TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 1f;
    }

    public void TempMoveForward_Off()
    {
        MoveForwards = false;

    }
    public void TempMoveBackwards_ON()
    {
        MoveBackwards = true;
        MoveForwards = false;
    }
    public void TempMoveBackwards_Off()
    {
        MoveBackwards = false;

    }

    public void MoveCursorForward()
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 1f;
        }
        

    }
    public void MoveCursorForward2()
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 0.5f;
        }
        

    }

    public void MoveCursorForward3()
    {
        if (CursorCanMoveForwards == true)
        {
            TeleportTestCursor.transform.position += TeleportTestCursor.transform.forward * 1.5f;
        }
        

    }

    public void MoveCursorBackwards()
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 1f;
        }
        

    }
    public void MoveCursorBackwards2()
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 0.5f;
        }
        

    }
    public void MoveCursorBackwards3()
    {
        if (CursorCanMoveBackwards == true)
        {
            TeleportTestCursor.transform.position -= TeleportTestCursor.transform.forward * 1.5f;
        }
        

    }

    public void ResetCursor()
    {
        TeleportTestCursor.transform.position = Cursor2_LocationStart;
    }


}
