using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    public bool RightCycle = false; //boolean to cycle the display right
    public bool LeftCycle = false; //boolean to cycle the display left

    public GameObject Display; //reference to the slider display

    public GameObject VR_RightHand;
    
    // Start is called before the first frame update
    void Start()
    {
        VR_RightHand = GameObject.FindGameObjectWithTag("VR_RightHand");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left Hand" || other.gameObject.tag == "Right Hand" || other.gameObject.tag == "VR_RightHand" || other.gameObject.tag == "VR_LeftHand") //if the player's hand collides with the slider buttons
        {
            if (RightCycle == true) //if the player has pressed the right cycle button
            {
                Debug.Log("Cycle Right");
                //Display.SendMessage("IncrementDisplay");
                Display.GetComponent<SliderObject>().IncrementDisplay(); //runs the increment function on the slider display
                //gameObject.transform.parent.GetComponent<SliderExhibitTelemetry>().ButtonPressed += 1;
                gameObject.transform.parent.GetComponent<SliderExhibitTelemetryV2>().PushData("Increment Button Pressed");
            }

            else if (LeftCycle == true) //if the player has pressed the left cycle button
            {
                Debug.Log("Cycle Left");
                //Display.SendMessage("DecrementDisplay");
                Display.GetComponent<SliderObject>().DecrementDisplay(); //runs the decrement function on the slider display
                //gameObject.transform.parent.GetComponent<SliderExhibitTelemetry>().ButtonPressed += 1;
                gameObject.transform.parent.gameObject.GetComponent<SliderExhibitTelemetryV2>().PushData("Decrement Button Pressed");
            }
           
        }
    }
}
