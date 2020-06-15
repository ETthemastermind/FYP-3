using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObject : MonoBehaviour
{

    public GameObject Display;


    public GameObject[] DisplayBoards;
    public GameObject StartingDisplay;

   

    private float Dpad_Horizontal;

    private int CurrentDisplayBoard = 0;

    public static bool Dpad_Active = false;

    public GameObject TriggerArea;

    public bool PlayerInArea = false;

    public GameObject SliderGUI;

    public bool ActiveArtefact;

    public bool Initialised = false;

    public GameObject ProgressSlider;


    public GameObject Player;
    public AudioSource AS;
    public AudioClip ButtonPress;


    // Start is called before the first frame update

    private void Awake()
    {
        SliderGUI = GameObject.FindGameObjectWithTag("SliderGUI");
    }
    void Start()
    {
        SliderGUI.SetActive(false);
        //Instantiate(DisplayBoards[0], gameObject.transform.position, gameObject.transform.rotation * DisplayRotOffset);
        //Debug.Log(DisplayBoards.Length);
        ProgressSlider.GetComponent<Slider>().maxValue = DisplayBoards.Length - 1;

        
        Player = GameObject.FindGameObjectWithTag("Player");
        AS = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        if (Initialised == false)
        {
            for (int i = 1; i != DisplayBoards.Length; i++)
            {
                //Debug.Log(DisplayBoards[i].gameObject.name);
                DisplayBoards[i].gameObject.SetActive(false);

            }

            Initialised = true;
        }
        PlayerInArea = TriggerArea.GetComponent<AreaEntered>().PlayerInTrigger;
        Dpad_Horizontal = Input.GetAxisRaw("Dpad_Horizontal");
        //Debug.Log("debug:" + Dpad_Horizontal);

        if (PlayerInArea == false & ActiveArtefact == true)
        {
            SliderGUI.SetActive(false);
            ActiveArtefact = false;



        }


        if (PlayerInArea == true & ActiveArtefact == false)
        {
            SliderGUI.SetActive(true);
            ActiveArtefact = true;
        }

        if (PlayerInArea == true & ActiveArtefact == true)
        {
            if (Dpad_Horizontal == 1 & Dpad_Active == false)
            {
                //Debug.Log("Right Pressed");
                Dpad_Active = true;
                IncrementDisplay();
            }

            else if (Dpad_Horizontal == -1 & Dpad_Active == false)
            {
                //Debug.Log("Left Pressed");
                Dpad_Active = true;
                DecrementDisplay();

            }

            else if (Dpad_Horizontal == 0)
            {
                //Debug.Log("Dpad Released");
                Dpad_Active = false;
            }

        }

    }

    public void IncrementDisplay()
    {
        //Debug.Log(CurrentMat);
        DisplayBoards[CurrentDisplayBoard].SetActive(false);
        Debug.Log("Incremeting Display");
        CurrentDisplayBoard = CurrentDisplayBoard + 1;
        if (CurrentDisplayBoard == DisplayBoards.Length)
        {
            CurrentDisplayBoard = 0;
            

        }
        DisplayBoards[CurrentDisplayBoard].SetActive(true);
        ProgressSlider.GetComponent<Slider>().value = CurrentDisplayBoard;
        //Display.GetComponent<Renderer>().material = materials[CurrentMat];
        AS.PlayOneShot(ButtonPress);

    }


    public void DecrementDisplay()
    {
        //Debug.Log(CurrentMat);
        DisplayBoards[CurrentDisplayBoard].SetActive(false);
        Debug.Log("Decremeting Display");
        CurrentDisplayBoard = CurrentDisplayBoard - 1;
        if (CurrentDisplayBoard == -1)
        {
            CurrentDisplayBoard = (DisplayBoards.Length - 1);

        }

        DisplayBoards[CurrentDisplayBoard].SetActive(true);
        ProgressSlider.GetComponent<Slider>().value = CurrentDisplayBoard;
        //Display.GetComponent<Renderer>().material = materials[CurrentMat];
        AS.PlayOneShot(ButtonPress);

    }


}

