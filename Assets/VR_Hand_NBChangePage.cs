using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Hand_NBChangePage : MonoBehaviour
{
    public bool NextPage; //booleans so I can pick if this object increments of decrements
    public bool LastPage;
    public GameObject FingerTip; //reference to the right finger tip.
    public GameObject PageController; //Reference to the page controller
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
        if (other.gameObject.name == "Vr_RightIndex_Track")
        {
            if (NextPage == true)
            {
                PageController.GetComponent<PageController>().IncrementPage();
                gameObject.transform.parent.GetComponent<NotebookTelemetrySystem>().PushData("Page turned using gesture (Increment)",System.DateTime.Now.ToLongTimeString(),"N/A","N/A");
            }

            else if (LastPage == true)
            {
                PageController.GetComponent<PageController>().DecrementPage();
                gameObject.transform.parent.GetComponent<NotebookTelemetrySystem>().PushData("Page turned using gesture (Decrement)", System.DateTime.Now.ToLongTimeString(), "N/A", "N/A");
            }
        }

    }
}
