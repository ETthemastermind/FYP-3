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
    

    public void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        //TeleportCursor = GameObject.FindGameObjectWithTag("TeleportCursor");
        
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
       
    }

    public void GestureActive()
    {
        IsPointing = true;
        

    }

    public void GestureInactive()
    {

        IsPointing = false;
        
    }
}




