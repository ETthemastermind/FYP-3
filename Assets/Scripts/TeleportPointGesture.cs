using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleportPointGesture : MonoBehaviour
{
    //public bool IsPointing;
    public LineRenderer LR; //ref for the line renderer
    //public GameObject FingerTip;

    public GameObject TeleportCursor;
    public GameObject TeleportCursorScript;
    public GameObject Camera;
    public GameObject Player;
    public float WaitBeforeTP = 5f;
    public float ElapsedTime;
    public bool MovePlayer = false;

    public bool TeleportFadeInTest;  //both tests here are for debug
    public bool TeleportFadeOutTest;
    public bool Teleport;
    public bool Loading;
    

    public void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        //Player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    public void Update()
    {
        /*
        if (IsPointing == true) //was making a line renderder arc for it a while ago, doesnt do anything yet
        {
            LR.SetPosition(0, FingerTip.transform.position);
            LR.SetPosition(2, TeleportCursor.transform.position);

            //testing adding arcing points
            Vector3 MidPoint = (FingerTip.transform.position + TeleportCursor.transform.position) / 2;
            float MidPoint_Y = (FingerTip.transform.position.y + MidPoint.y) / 2;
            Vector3 NewMidPoint = new Vector3(MidPoint.x, MidPoint.y + MidPoint_Y, MidPoint.z);
            LR.SetPosition(1, NewMidPoint);
        }
        */
        if (TeleportFadeInTest == true)
        {
            TeleportFadeIn();
            TeleportFadeInTest = false;


        }

        if (TeleportFadeOutTest == true)
        {
            TeleportFadeOut();
            TeleportFadeOutTest = false;

        }

        if (Teleport == true) //if teleport is true, gets set from the teleport cursor script
        {
            TeleportFadeIn(); //fades the camera out to black
            if (ElapsedTime < WaitBeforeTP) //waits for time to elapse
            {
                ElapsedTime += Time.deltaTime;
            }
            else if (ElapsedTime > WaitBeforeTP) //if time has elapsed
            {
                
                Vector3 CursorLocation = TeleportCursor.transform.position; //get location of the teleport cursor
                Vector3 NewPlayerLocation = new Vector3(CursorLocation.x, Player.transform.position.y, CursorLocation.z); //creates a vector 3 where the player is going to move to

                Player.transform.position = NewPlayerLocation; //moves the player to the new location
                Debug.Log(Player.transform.position);

                TeleportFadeOut(); //fades back out
                Teleport = false; //sets teleport bool to false
                //TeleportCursorScript.GetComponent<TeleportCursor>().ResetCursor();

                ElapsedTime = 0f; // resets elapsed time
                
            }

            

            
        }


       
    }
    /*
    public void GestureActive()
    {
        IsPointing = true;
        

    }

    public void GestureInactive()
    {

        IsPointing = false;
        
    }
    */
    public void TeleportFadeIn() //calls the fade in script, method on the teleport cursor script
    {
        
        Camera.GetComponent<TeleportCursor>().TeleportFadeIn();
        
        

    }

    public void TeleportFadeOut() //calls the fade out script, method on the teleport cursor script
    {
        
        Camera.GetComponent<TeleportCursor>().TeleportFadeOut();

    }
    

   
    

    
    

    

}






