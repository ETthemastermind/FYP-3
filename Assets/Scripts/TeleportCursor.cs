using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleportCursor : MonoBehaviour
{
    public GameObject TeleportTestCursor;
    public GameObject Cursor2;

    public Vector3 Cursor2_Location;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (MoveForwards == true)
        {
            TeleportTestCursor.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        else if (MoveBackwards == true)
        {
            TeleportTestCursor.transform.Translate(Vector3.back * Speed * Time.deltaTime);

        }
        */
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
}
