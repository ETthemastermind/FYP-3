using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialController : MonoBehaviour
{
    //Phase 1 variables of the tutorial//
    public bool TriggerPhase1;
    public GameObject CuratorPortrait; //ref for the curator portrait
    public Material CuratorPortraitMat; //ref for the material on the portrait (woman with blurred musuem background
    public Color LerpedColour = Color.black; //ref for the lerped color for the emissive, black is no emissive

    //Phase 2 variables
   
    // Start is called before the first frame update
    void Start()
    {
        CuratorPortraitMat = CuratorPortrait.GetComponent<Renderer>().materials[1]; //finds the correct mat on the portrait 
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerPhase1 == true) //for now, using booleans to trigger
        {
            Phase1(); //run phase 1
        }
    }

    public void Phase1()
    {
        Debug.Log("Phase 1 tutorial active");
        LerpedColour = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1)); //lerp between black and yellow, gives a nice tutorial glowing effect
        CuratorPortraitMat.SetColor("_EmissionColor", LerpedColour); //sets the emissive color of the portrait

    }

    public void Phase2()
    {
        TriggerPhase1 = false; //deactivates phase one
        Debug.Log("Phase 2 tutorial active");

    }
}
