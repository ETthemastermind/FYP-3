using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntered : MonoBehaviour
{

    public bool PlayerInTrigger = false;
    public ParticleSystem PS;
    public float DefaultGM;
    public float GM;
    // Start is called before the first frame update
    void Start()
    {
        PS = gameObject.GetComponent<ParticleSystem>();
        DefaultGM = PS.gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInTrigger = true;

            PS.gravityModifier = GM;

            var Shape = PS.shape;

            Shape.arcMode = ParticleSystemShapeMultiModeValue.Random;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInTrigger = false;

            PS.gravityModifier = DefaultGM;
            var Shape = PS.shape;
            Shape.arcMode = ParticleSystemShapeMultiModeValue.Loop;
        }
    }
}
