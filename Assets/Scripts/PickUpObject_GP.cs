using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject_GP : MonoBehaviour
{
    public GameObject TriggerArea;
    public bool PlayerInArea = false;

    public GameObject Inspect_Pos;
    public GameObject Artifact_Home;
    private Vector3 Artifact_Start;
    private Vector3 Artifact_Orient;
    public Vector3 Artifact_Size;
    public Vector3 CurrentSize;
    public Vector3 MinSize;
    public Vector3 MaxSize;
    private float LeftTrigger;
    private float RightTrigger;
    private float Dpad_Vertical;
    private float Dpad_Horizontal;

    private float MoveSpeed = 100f;


    private bool Artifact_Holding = false;


    public GameObject PressA;
    public GameObject PressB;
    public GameObject InfoBackDrop;
    public Text DisplayedInformation;

    public Text Keyword1;
    public Text Keyword2;
    public Text Keyword3;
    public Text Keyword4;


    private bool Dpad_Active_H = false;
    private bool Dpad_Active_V = false;

    public bool ActiveScript = false;


    // Start is called before the first frame update

    private void Awake()
    {
        PressA = GameObject.FindGameObjectWithTag("Display_PressA");
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
        Artifact_Start = gameObject.transform.position;
        Artifact_Orient = gameObject.transform.rotation.eulerAngles;
        Artifact_Size = gameObject.transform.lossyScale;

        


        Inspect_Pos = GameObject.FindGameObjectWithTag("Inspect_Pos");
        Artifact_Home = gameObject.transform.parent.gameObject;
        TriggerArea = Artifact_Home.gameObject.transform.Find("Glowing Ring").gameObject;

        PressB.SetActive(false);
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



    



