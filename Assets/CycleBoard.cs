using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBoard : MonoBehaviour
{
    public GameObject TutorialController;
    public int ActivePhase;
    public GameObject[] PedestalsInSameTutorialArea;
    public int[] PedestalsInSameTutorialArea_PhaseNumbers;
    public bool CycleRight;
    public bool CycleLeft;

    public int CurrentPedestal = 0;
    public int NextPedestal;

     
    // Start is called before the first frame update
    void Start()
    {
        TutorialController = GameObject.FindGameObjectWithTag("TutorialController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementTutDisplay()
    {
        Debug.Log("Increment Pedestal");
        NextPedestal = CurrentPedestal += 1;
        if (NextPedestal > PedestalsInSameTutorialArea.Length)
        {
            NextPedestal = CurrentPedestal -= 1;

        }

       
        PedestalsInSameTutorialArea[NextPedestal].SetActive(true);
        NextPedestal = CurrentPedestal;
        //PedestalsInSameTutorialArea[CurrentPedestal].SetActive(false);


    }

    public void DecrementTutDisplay()
    {
        Debug.Log("Decrement Pedestal");
        NextPedestal = CurrentPedestal -= 1;
        if (NextPedestal > PedestalsInSameTutorialArea.Length)
        {
            NextPedestal = CurrentPedestal += 1;
            

        }


        PedestalsInSameTutorialArea[NextPedestal].SetActive(true);
        NextPedestal = CurrentPedestal;
        PedestalsInSameTutorialArea[CurrentPedestal].SetActive(false);


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Vr_LeftIndex_Track" || other.gameObject.name == "Vr_RightIndex_Track")
        {
            if (CycleRight == true)
            {
                IncrementTutDisplay();
            }

            if (CycleLeft == true)
            {
                DecrementTutDisplay();
            }

        }
       
    }
}
