using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuideBookLM : MonoBehaviour
{
    public GameObject GuideBook;
    public GameObject Palm;
    public bool ActiveGesture = false;
    // Start is called before the first frame update
    void Start()
    {
        GuideBook.transform.parent = Palm.transform;
        GuideBook.transform.localPosition = new Vector3(0.2f, -0.05f, 0f);
        GuideBook.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Palm.transform.rotation.x > 0.5 && Palm.transform.rotation.x < 0.6)
        {
            GuideBook.SetActive(true);
        }
        */
    }
    public void Active()
    {
        if (ActiveGesture == false )
        {
            GuideBook.GetComponent<NotebookTelemetrySystem>().PushData("Guidebook Opened");
            Debug.Log("Active Gesture: Spawn Guidebook");
            GuideBook.SetActive(true);
            ActiveGesture = true;
        }




    }

    public void Inactive()
    {

        if (ActiveGesture == true)
        {
            GuideBook.GetComponent<NotebookTelemetrySystem>().PushData("Guidebook Closed");
            ActiveGesture = false;
            Debug.Log("Inactive Gesture: Spawn Guidebook");
            GuideBook.SetActive(false);
        }





    }


    public void PalmUpTrue()
    {
        Debug.Log("Palm Facing Up");
    }

    public void PalmUpFalse()
    {
        Debug.Log("Palm Not Facing Up");
    }

}
