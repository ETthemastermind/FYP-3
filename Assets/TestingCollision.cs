using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCollision : MonoBehaviour
{

    public GameObject RightSideObject;

    private bool Active_Gesture = false;
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

        if (other.gameObject.tag == "Right Hand" & Active_Gesture == true)
        {
            //Debug.Log("Right Hand in Trigger");

            Vector3 thing = RightSideObject.transform.position + transform.position;
            float dotProduct = Vector3.Dot(transform.right, thing);

            if (dotProduct > 0f)
            {
                Debug.Log("Hand Entered From Left Side");
                gameObject.GetComponent<Renderer>().material.color = Color.blue;

            }

            if (dotProduct < 0f)
            {
                Debug.Log("Hand Entered from Right Side");
                gameObject.GetComponent<Renderer>().material.color = Color.red;

            }

        }
    }
    public void ActiveGesture()
    {
        Active_Gesture = true;
        Debug.Log("Gesture Active");
    }

    public void DeactiveGesture()
    {
        Active_Gesture = false;
        Debug.Log("Gesture Inactive");

    }
}
