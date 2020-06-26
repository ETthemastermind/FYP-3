using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWall : MonoBehaviour
{
    public bool CursorInMap;
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
        
        if (CursorInMap == false && other.gameObject.tag == "MapArea")
        {
            CursorInMap = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (CursorInMap == true && other.gameObject.tag == "MapArea")
        {
            CursorInMap = false;
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CursorInWall = true;

            Debug.Log("Cursor Thru Wall");
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CursorInWall = false;

            Debug.Log("Cursor Thru Wall");
        }

    }
    */




}
