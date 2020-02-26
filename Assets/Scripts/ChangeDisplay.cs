using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    public bool RightCycle = false;
    public bool LeftCycle = false;

    public GameObject Display;
    
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
        if (other.gameObject.tag == "Left Hand" || other.gameObject.tag == "Right Hand")
        {
            if (RightCycle == true)
            {
                Debug.Log("Cycle Right");
                //Display.SendMessage("IncrementDisplay");
                Display.GetComponent<SliderObject>().IncrementDisplay();
            }

            else if (LeftCycle == true)
            {
                Debug.Log("Cycle Left");
                //Display.SendMessage("DecrementDisplay");
                Display.GetComponent<SliderObject>().DecrementDisplay();
            }
           
        }
    }
}
