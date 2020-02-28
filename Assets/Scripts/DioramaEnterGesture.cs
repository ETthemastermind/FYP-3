using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaEnterGesture : MonoBehaviour
{
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

    public GameObject SOSR;

    public GameObject SOSRObject;

    public GameObject DebugSphere;
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PalmDistance = Vector3.Distance(RightPalm.transform.position, LeftPalm.transform.position);
        SOSRObject = SOSR.GetComponent<SmallObject_SpeechRec>().Artefact;
        if (SOSRObject.transform.parent.gameObject.tag == "DioramaDisplay")
        {
            if (GestureActive == true)
            {
                LR.enabled = true;
                LR.SetPosition(0, RightPalm.transform.position);
                LR.SetPosition(1, LeftPalm.transform.position);
                
                if (PalmDistance >= 0 && PalmDistance <= (MaxHandDistance / 3))
                {
                    Debug.Log("Max Distance Reached");
                    LR.material = Red;
                    ElapsedTime = 0f;
                    DebugSphere.GetComponent<Renderer>().material.color = Color.white;

                }
                else if (PalmDistance >= (MaxHandDistance / 3) && (PalmDistance <= (MaxHandDistance / 3) * 2))
                {
                    Debug.Log("Max Distance Reached");
                    LR.material = Orange;
                    ElapsedTime = 0f;
                    DebugSphere.GetComponent<Renderer>().material.color = Color.white;

                }
                else if (PalmDistance >= MaxHandDistance)
                {
                    Debug.Log("Max Distance Reached");
                    LR.material = Green;

                    if (ElapsedTime <= Timer)
                    {
                        ElapsedTime += Time.deltaTime;

                    }
                    else if (ElapsedTime >= Timer)
                    {
                        DebugSphere.GetComponent<Renderer>().material.color = Color.red;

                    }


                    


                    

                }
            }

            else if (GestureActive == false)
            {
                LR.enabled = false;

            }


        }
       
        
    }

    public void DioramaGestureActive()
    {

        if (PalmDistance <= 0.5f)
        {
            GestureActive = true;

        }
        

    }

    public void DioramaGestureInactive()
    {
        GestureActive = false;
        DebugSphere.GetComponent<Renderer>().material.color = Color.white;

    }

   


}
