using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject_GP : MonoBehaviour
{
    public GameObject TriggerArea; //reference for the trigger area / artefact ring of the pedestal
    public bool PlayerInArea = false; //bool to check if the player is in the area

    public GameObject Inspect_Pos; //reference for the gameobject where picked up objects go, GO child of the FPS GP_Player
    public GameObject Artifact_Home; //reference for the home pedestal of the artefact
    private Vector3 Artifact_Start; //reference for the start location of the artefact
    private Vector3 Artifact_Orient; //referecnce for the start rotation of the artefact
    public Vector3 Artifact_Size; //reference for the default size of the artefact
    public Vector3 CurrentSize; // reference for the current size of the artefact
    public Vector3 MinSize;  //refernces for the min and max size the object can become
    public Vector3 MaxSize;
    private float LeftTrigger; //reference for the float values when gamepad buttons are pressed
    private float RightTrigger;
    private float Dpad_Vertical;
    private float Dpad_Horizontal;

    private float MoveSpeed = 100f; //reference for a movement speed


    private bool Artifact_Holding = false; //bool for if an artefact is being held


    public GameObject PressA; // references for GUI game objects
    public GameObject PressB;
    public GameObject InfoBackDrop;
    public Text DisplayedInformation;

    public Text Keyword1;
    public Text Keyword2;
    public Text Keyword3;
    public Text Keyword4;


    private bool Dpad_Active_H = false; //bool for if the Dpad is being used
    private bool Dpad_Active_V = false;

    public bool ActiveScript = false;


    // Start is called before the first frame update

    private void Awake()
    {
        PressA = GameObject.FindGameObjectWithTag("Display_PressA"); //finds GUI elements
        PressB = GameObject.FindGameObjectWithTag("Display_PressB");
        InfoBackDrop = GameObject.FindGameObjectWithTag("InfoGUI");
        DisplayedInformation = GameObject.FindGameObjectWithTag("Text_Info").GetComponent<Text>();

        Keyword1 = PressB.gameObject.transform.GetChild(5).GetComponentInChildren<Text>();
        Keyword2 = PressB.gameObject.transform.GetChild(6).GetComponentInChildren<Text>();
        Keyword3 = PressB.gameObject.transform.GetChild(7).GetComponentInChildren<Text>();
        Keyword4 = PressB.gameObject.transform.GetChild(8).GetComponentInChildren<Text>();
    }
    void Start()
    {
        Artifact_Start = gameObject.transform.position; //stores the default location, rotation and size of the object
        Artifact_Orient = gameObject.transform.rotation.eulerAngles;
        Artifact_Size = gameObject.transform.lossyScale;

        


        Inspect_Pos = GameObject.FindGameObjectWithTag("Inspect_Pos");  //finds the inspect postion from the player 
        Artifact_Home = gameObject.transform.parent.gameObject; //finds the home pedestal of the artefact
        TriggerArea = Artifact_Home.gameObject.transform.Find("Glowing Ring").gameObject; //finds the trigger area of the object

        PressB.SetActive(false); //turns the gui off
        PressA.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInArea = TriggerArea.GetComponent<AreaEntered>().PlayerInTrigger;

        if (PlayerInArea == true & ActiveScript == false)
        {
            ActiveScript = true;
            PressA.SetActive(true);

            



        }
        if (PlayerInArea == false & ActiveScript == true)
        {
            ActiveScript = false;
            PressA.SetActive(false);

        }

        if (ActiveScript == true || Artifact_Holding == true)
        {
            PickUpArtefact();
            ManipulateArtefact();
        }

    }
    

    public void PickUpArtefact()
    {
        if (Input.GetButtonDown("Gamepad_A") & Artifact_Holding == false)
        {
            Debug.Log("A button pressed");
            gameObject.transform.position = Inspect_Pos.transform.position;
            CurrentSize = gameObject.transform.lossyScale;
            MinSize = CurrentSize / 3;
            Debug.Log(MinSize);
            MaxSize = CurrentSize * 3;
            Debug.Log(MaxSize);
            gameObject.transform.parent = Inspect_Pos.transform;

            


            PressA.SetActive(false);
            PressB.SetActive(true);
            Artifact_Holding = true;
            Keyword1.text = gameObject.GetComponent<AssignInformation>().keywords[0];
            Keyword2.text = gameObject.GetComponent<AssignInformation>().keywords[1];
            Keyword3.text = gameObject.GetComponent<AssignInformation>().keywords[2];
            Keyword4.text = gameObject.GetComponent<AssignInformation>().keywords[3];
        }


    }

    public void ManipulateArtefact()
    {
        if (Input.GetButtonDown("Gamepad_B") & Artifact_Holding == true)
        {
            gameObject.transform.position = Artifact_Start;
            gameObject.transform.eulerAngles = Artifact_Orient;

            gameObject.transform.parent = null;
            gameObject.transform.localScale = Artifact_Size;
            gameObject.transform.parent = Artifact_Home.transform;
            
            PressB.SetActive(false);
            InfoBackDrop.SetActive(false);

            if (PlayerInArea == true)
            {
                PressA.SetActive(true);
            }
            

            Artifact_Holding = false;
        }

        if (Artifact_Holding == true)
        {
            LeftTrigger = Input.GetAxis("Right_Trigger");
            RightTrigger = Input.GetAxis("Left_Trigger");

            Dpad_Horizontal = Input.GetAxis("Dpad_Horizontal");
            Dpad_Vertical = Input.GetAxis("Dpad_Vertical");


            if (LeftTrigger == 1)
            {
                Debug.Log("Left Trigger Active");
                gameObject.transform.Rotate(Vector3.left, MoveSpeed * Time.deltaTime);
            }

            if (RightTrigger == 1)
            {
                Debug.Log("Right Trigger Active");
                gameObject.transform.Rotate(Vector3.right, MoveSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Left_Bumper"))
            {
                Debug.Log("Left Bumper Pressed");
                gameObject.transform.Rotate(Vector3.back, MoveSpeed * Time.deltaTime);

            }

            if (Input.GetButton("Right_Bumper"))
            {
                Debug.Log("Right Bumper Pressed");
                gameObject.transform.Rotate(Vector3.forward, MoveSpeed * Time.deltaTime);

            }

            else
            {
                // do nothing



            }

            if (Dpad_Horizontal == 1 & Dpad_Active_H == false)
            {
                InfoBackDrop.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[1];
                Dpad_Active_H = true;
            }
            else if (Dpad_Horizontal == -1 & Dpad_Active_H == false)
            {
                InfoBackDrop.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[3];
                Dpad_Active_H = true;
            }
            else if (Dpad_Horizontal == 0 & Dpad_Active_H == true)
            {
                Dpad_Active_H = false;
            }

            else if (Dpad_Vertical == 1 & Dpad_Active_V == false)
            {
                InfoBackDrop.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[0];
                Dpad_Active_V = true;
            }

            else if (Dpad_Vertical == -1 & Dpad_Active_V == false)
            {
                InfoBackDrop.SetActive(true);
                DisplayedInformation.GetComponent<Text>().text = gameObject.GetComponent<AssignInformation>().RelevantInfo[2];
                Dpad_Active_V = true;

            }
            else if (Dpad_Horizontal == 0 & Dpad_Active_V == true)
            {
                Dpad_Active_V = false;
            }

            else
            {
                //do nothing

            }


            if (Input.GetButton("Gamepad_X"))
            {
                CurrentSize = gameObject.transform.lossyScale;
                if (CurrentSize.x <= MaxSize.x)
                {
                    Debug.Log("Make Bigger");
                    gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                }
                


            }

            else if (Input.GetButton("Gamepad_Y"))
            {
                CurrentSize = gameObject.transform.lossyScale;
                if (CurrentSize.x >= MinSize.x)
                {
                    Debug.Log("Make Smaller");
                    gameObject.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
                    

                }
                

            }

            else
            {
                //do nothing

            }
        }



    }
}



    



