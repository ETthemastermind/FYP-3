using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntered : MonoBehaviour   //script for when the player enters the interact ring
{

    public bool PlayerInTrigger = false; //bool for when player is in the ring
    public ParticleSystem PS;  //particle system on ring
    public float DefaultGM; //default gravity modifier on the particle system
    public float GM; //particle system gravity modifier
    // Start is called before the first frame update
    void Start()
    {
        PS = gameObject.GetComponent<ParticleSystem>(); //get the particle system component
        DefaultGM = PS.gravityModifier; //grab the current gravity modifier on the particle system
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //if the object enterting the trigger is the player
        {
            PlayerInTrigger = true; //flip the boolean on

            PS.gravityModifier = GM; //change the gravity modifier to the value set in the inspector, lets the particles float

            var Shape = PS.shape; //get the shape component from the particle system as a variable

            Shape.arcMode = ParticleSystemShapeMultiModeValue.Random; //change the shape mode so the circle is broken
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") //if the player leaves the trigger
        {
            PlayerInTrigger = false; //flip the boolean off

            PS.gravityModifier = DefaultGM; // reset the ring to how it was before 
            var Shape = PS.shape;
            Shape.arcMode = ParticleSystemShapeMultiModeValue.Loop;
        }
    }
}
