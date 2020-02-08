using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObject1 : MonoBehaviour
{

    public GameObject Display;


    public Material[] materials;

    private float Dpad_Horizontal;

    private int CurrentMat = 0;

    public static bool Dpad_Active = false;

    public GameObject TriggerArea;

    public bool PlayerInArea = false;

    public GameObject SliderGUI;

    public bool ActiveArtefact;



    // Start is called before the first frame update

    private void Awake()
    {
        SliderGUI = GameObject.FindGameObjectWithTag("SliderGUI");
    }
    void Start()
    {
        Display.GetComponent<Renderer>().material = materials[CurrentMat];
        SliderGUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
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

        //Debug.Log("Incremeting Display");
        CurrentMat = CurrentMat + 1;
        if (CurrentMat == materials.Length)
        {
            CurrentMat = 0;

        }

        Display.GetComponent<Renderer>().material = materials[CurrentMat];
    }


    public void DecrementDisplay()
    {
        //Debug.Log(CurrentMat);

        //Debug.Log("Incremeting Display");
        CurrentMat = CurrentMat - 1;
        if (CurrentMat == -1)
        {
            CurrentMat = (materials.Length - 1);

        }

        Display.GetComponent<Renderer>().material = materials[CurrentMat];


    }


}

