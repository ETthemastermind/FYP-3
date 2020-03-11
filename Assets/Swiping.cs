using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Swiping : MonoBehaviour
{
    public bool GestureActive = false;
    public bool HandTriggered = false;
    public GameObject Palm;
    public GameObject PageController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    

    public void SwipeGestureActive()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        GestureActive = true;
    }

    public void SwipeGestureInactive()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        GestureActive = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right Hand")
        {
            if (GestureActive == true)
            {
                Vector3 PalmToSwipe = Palm.transform.position - transform.position;
                float DotProduct = Vector3.Dot(transform.up, PalmToSwipe);

                if (DotProduct < 0f)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    PageController.GetComponent<PageController>().IncrementPage();
                    GestureActive = false;

                }

                else if (DotProduct > 0f)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    PageController.GetComponent<PageController>().DecrementPage();
                    GestureActive = false;
                }





            }

           
        }
    }
}
