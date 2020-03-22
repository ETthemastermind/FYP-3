using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleportPointGesture : MonoBehaviour
{
    public bool IsPointing;
    public LineRenderer LR;
    public GameObject FingerTip;

    public GameObject TeleportCursor;
    public GameObject Camera;
    public GameObject Player;
    public float WaitBeforeTP = 5f;
    public float ElapsedTime;
    public bool MovePlayer = false;

    public bool TeleportFadeInTest;
    public bool TeleportFadeOutTest;
    public bool Teleport;
    public bool Loading;
    

    public void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    public void Update()
    {
        if (IsPointing == true)
        {
            LR.SetPosition(0, FingerTip.transform.position);
            LR.SetPosition(2, TeleportCursor.transform.position);

            //testing adding arcing points
            Vector3 MidPoint = (FingerTip.transform.position + TeleportCursor.transform.position) / 2;
            float MidPoint_Y = (FingerTip.transform.position.y + MidPoint.y) / 2;
            Vector3 NewMidPoint = new Vector3(MidPoint.x, MidPoint.y + MidPoint_Y, MidPoint.z);
            LR.SetPosition(1, NewMidPoint);
        }

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

        if (Teleport == true)
        {
            TeleportFadeIn();
            if (ElapsedTime < WaitBeforeTP)
            {
                ElapsedTime += Time.deltaTime;
            }

            else if (ElapsedTime > WaitBeforeTP)
            {
                Vector3 CursorLocation = TeleportCursor.transform.position;
                Vector3 NewPlayerLocation = new Vector3(CursorLocation.x, Player.transform.position.y, CursorLocation.z);
                Player.transform.position = NewPlayerLocation;

                TeleportFadeOut();

                Teleport = false;
                ElapsedTime = 0f;
            }
        }


       
    }

    public void GestureActive()
    {
        IsPointing = true;
        

    }

    public void GestureInactive()
    {

        IsPointing = false;
        
    }

    public void TeleportFadeIn()
    {
        
        Camera.GetComponent<TeleportCursor>().TeleportFadeIn();
        
        

    }

    public void TeleportFadeOut()
    {
        
        Camera.GetComponent<TeleportCursor>().TeleportFadeOut();

    }

    public void TeleportToCursor()
    {
        TeleportFadeIn();
       
        Vector3 CursorLocation = TeleportCursor.transform.position;
        Vector3 NewPlayerLocation = new Vector3(CursorLocation.x, Player.transform.position.y, CursorLocation.z);
        Player.transform.position = NewPlayerLocation;
        
        TeleportFadeOut();
        

    }

    IEnumerator WaitAfterFade()
    {
        yield return new WaitForSeconds(10f);
        

        Debug.Log("TimerDone");

    }

    

    
    

    

}






