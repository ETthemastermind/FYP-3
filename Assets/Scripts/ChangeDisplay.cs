using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    public bool RightCycle = false; //boolean to cycle the display right
    public bool LeftCycle = false; //boolean to cycle the display left

    public GameObject Display; //reference to the slider display
    
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
        if (other.gameObject.tag == "Left Hand" || other.gameObject.tag == "Right Hand") //if the player's hand collides with the slider buttons
        {
            if (RightCycle == true) //if the player has pressed the right cycle button
            {
                Debug.Log("Cycle Right");
                //Display.SendMessage("IncrementDisplay");
                Display.GetComponent<SliderObject>().IncrementDisplay(); //runs the increment function on the slider display
            }

            else if (LeftCycle == true) //if the player has pressed the left cycle button
            {
                Debug.Log("Cycle Left");
                //Display.SendMessage("DecrementDisplay");
                Display.GetComponent<SliderObject>().DecrementDisplay(); //runs the decrement function on the slider display
            }
           
        }
    }
}
