using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public bool OutOfBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MapArea")
        {
            OutOfBounds = false;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MapArea")
        {
            OutOfBounds = true;
        }
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MapArea")
        {
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MapArea")
        {
            OutOfBounds = true;
            transform.position -= transform.forward * 5f * Time.deltaTime;
        }

    }
    */
}
