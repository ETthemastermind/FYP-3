using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTutBoard : MonoBehaviour
{
    public bool CycleRight;
    public bool CycleLeft;

    public GameObject Board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Vr_LeftIndex_Track" || other.gameObject.name == "Vr_RightIndex_Track")
        {
            if (CycleRight == true)
            {
                Board.GetComponent<CycleBoard>().IncrementTutDisplay();
            }

            if (CycleLeft == true)
            {
                Board.GetComponent<CycleBoard>(). DecrementTutDisplay();
            }

        }

    }
}
