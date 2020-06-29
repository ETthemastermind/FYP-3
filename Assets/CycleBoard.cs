﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBoard : MonoBehaviour
{
    public GameObject TutorialController;
    public int ActivePhase;
    public GameObject[] TutText;
    public bool CycleRight;
    public bool CycleLeft;
    public int[] RangeOfDisplays;
    public int CurrentPedestal = 0;
    public int NextPedestal;

    public bool TestRight;
    public bool TestLeft;
     
    // Start is called before the first frame update
    void Start()
    {
        TutorialController = GameObject.FindGameObjectWithTag("TutorialController");
        for (int i = 0; i < TutText.Length; i++)
        {
            if (i != RangeOfDisplays[0])
            {
                TutText[i].SetActive(false);
            }
        }

        CurrentPedestal = RangeOfDisplays[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        ActivePhase = TutorialController.GetComponent<TutorialController>().CurrentPhase;
        if (TestRight == true)
        {
            IncrementTutDisplay();
            TestRight = false;
        }

        if (TestLeft == true)
        {
            DecrementTutDisplay();
            TestLeft = false;
        }
    }

    public void IncrementTutDisplay()
    {

        Debug.Log("Increment Tut Board");
        TutText[CurrentPedestal].SetActive(false);
        CurrentPedestal += 1;

        if (CurrentPedestal > RangeOfDisplays[1])
        {
            CurrentPedestal = RangeOfDisplays[1];
        }

        if (TutText[CurrentPedestal].GetComponent<TutorialAssociatedPhase>().PhaseNumber > ActivePhase)
        {
            CurrentPedestal -= 1;
        }
        TutText[CurrentPedestal].SetActive(true);
       

    }

    public void DecrementTutDisplay()
    {
        Debug.Log("Decrement Tut Board");
        TutText[CurrentPedestal].SetActive(false);
        CurrentPedestal -= 1;
        
        if (CurrentPedestal < RangeOfDisplays[0])
        {
            CurrentPedestal = RangeOfDisplays[0];
        }
        TutText[CurrentPedestal].SetActive(true);
        

    }

    
}
