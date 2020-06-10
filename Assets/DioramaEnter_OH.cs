using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class DioramaEnter_OH : MonoBehaviour
{
    public GameObject VR_RightHand;
    public GameObject VR_RightHand_Palm;
    public GameObject VR_LeftHand;
    public GameObject VR_LeftHand_Palm;
    public bool GestureActive;
    public float GestureThreshold;

    public GameObject Player;
    public AudioSource AS;
    public AudioClip TeleportSoundEffect;
    public bool AudioPlayed = false;
    

    public LineRenderer LR;

    public bool RightHandInPos;
    public bool LeftHandInPos;
    public float PalmDistance;
    public float MaxHandDistance;


    public Material Red;
    public Material Orange;
    public Material Green;

    public float Timer;
    public float ElapsedTime;
    /*
    public GameObject RX;
    public GameObject RY;
    public GameObject RZ;
    public GameObject RW;
    public GameObject LX;
    public GameObject LY;
    public GameObject LZ;
    public GameObject LW;
    */

    public GameObject DioramaDisplay;
    public GameObject DioramaStand;
    public bool InArea = false;
    public int LevelToLoad;


    // Start is called before the first frame update
    void Start()
    {
        //VR_LeftHand = GameObject.FindGameObjectWithTag("VR_LeftHand");
        //VR_RightHand = GameObject.FindGameObjectWithTag("VR_RightHand");
        
        LR = gameObject.GetComponent<LineRenderer>();

        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
   
        
        
    }

    // Update is called once per frame
    void Update()
    {



        PalmDistance = Vector3.Distance(VR_RightHand_Palm.transform.position, VR_LeftHand_Palm.transform.position);

        

        /*
        RX.GetComponent<Text>().text = ("X" + VR_RightHand.transform.rotation.x.ToString());
        RY.GetComponent<Text>().text = ("Y" + VR_RightHand.transform.rotation.y.ToString());
        RZ.GetComponent<Text>().text = ("Z" + VR_RightHand.transform.rotation.z.ToString());
        RW.GetComponent<Text>().text = ("W" + VR_RightHand.transform.rotation.w.ToString());

        LX.GetComponent<Text>().text = ("X" + VR_LeftHand.transform.rotation.x.ToString());
        LY.GetComponent<Text>().text = ("Y" + VR_LeftHand.transform.rotation.y.ToString());
        LZ.GetComponent<Text>().text = ("Z" + VR_LeftHand.transform.rotation.z.ToString());
        LW.GetComponent<Text>().text = ("W" + VR_LeftHand.transform.rotation.w.ToString());
        //Debug.Log(VR_RightHand.transform.rotation.y);
        */
        /*
        // Check to see if the right hand is in position----------------------------------------------------------
        if (VR_RightHand.transform.rotation.x < 0.5f && VR_RightHand.transform.rotation.x > -0.5f)
        {

            RightHandInPos = true;
           

        }

        else
        {
            RightHandInPos = false;
        }
        //--------------------------------------------------------------------------------------------------
        /*
        //-------------------check to see if the left hand is in position-------------------------------------------
        if (VR_LeftHand.transform.rotation.x < -0.8f && VR_LeftHand.transform.rotation.x > -1f)
        {
            LeftHandInPos = true;
            
        }
        else
        {
            LeftHandInPos = false;

        }
        //---------------------------------------------------------------------------------------------------------//
        //---------------------------if both hands are in position activate the teleport ------------------------------// <---- not working, hands dont need to fancy anyway in particular
        */
        if (InArea == true)
        {
            
            

            if (PalmDistance >= 0 && PalmDistance <= GestureThreshold && GestureActive == false) //if the user moves their hands closes enough together, the gesture is activated
            {
                GestureActive = true;
                LR.enabled = true;
            }

            if (GestureActive == true)
            {
                LR.SetPosition(0, VR_LeftHand_Palm.transform.position);  //draws a line between the user's palm
                LR.SetPosition(1, VR_RightHand_Palm.transform.position);

            }
            
            

            if (PalmDistance >= 0 && PalmDistance <= (MaxHandDistance / 3) && GestureActive == true)
            {

                LR.material = Red; //When hands get put together, should be red. acts as a sort of loading bar.
                ElapsedTime = 0f;
                //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

            }
            else if (PalmDistance >= (MaxHandDistance / 3) && (PalmDistance <= (MaxHandDistance / 3) * 2) && GestureActive == true)
            {

                LR.material = Orange;
                ElapsedTime = 0f;
                //DebugSphere.GetComponent<Renderer>().material.color = Color.white;

            }
            else if (PalmDistance >= (MaxHandDistance / 3) * 2 && GestureActive == true)
            {
                Debug.Log("Max Distance Reached");
                LR.material = Green;

                if (ElapsedTime <= Timer) //hold the green position for a few seconds
                {
                    ElapsedTime += Time.deltaTime;

                }
                else if (ElapsedTime >= Timer)
                {
                    //DebugSphere.GetComponent<Renderer>().material.color = Color.red;
                    //FadeToLevel(2);
                    if (AudioPlayed == false)
                    {
                        AS.PlayOneShot(TeleportSoundEffect);
                        AudioPlayed = true;
                    }
                    
                    DioramaStand.GetComponent<LoadLevel>().OpenScene();

                }

            }
            
        }

        else
        {
            LR.enabled = false;
            
        }

        
        if (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.A_Button.GetState(SteamVR_Input_Sources.RightHand) == true && SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.LeftHand) == true && SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.LeftHand) == true && SteamVR_Actions._default.X_Button.GetState(SteamVR_Input_Sources.LeftHand) == true) //need a way for the user to cancel, cancel by closing their hands, this is going to be one hell of an if statement
        {
            GestureActive = false;
            LR.enabled = false;
        }
        
        
        

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
}
