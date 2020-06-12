using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExhibitObserver : MonoBehaviour
{
    public GameObject InteractRing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "InteractRing")

        {
            InteractRing = other.gameObject;

        }   
    }

    public void OnTriggerExit(Collider other)
    {
        InteractRing = null;
        
    }
}
