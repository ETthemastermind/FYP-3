using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCursor : MonoBehaviour
{
    public GameObject TeleportTestCursor;
    public GameObject Cursor2;

    public Vector3 Cursor2_Location;
    public bool MoveForward;
    public bool MoveBackward;
    public float Speed = 5f;

    public float MaxDistance;
    public float CurrentDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDistance = Vector3.Distance(transform.position, TeleportTestCursor.transform.position);

        if (MoveForward == true && Vector3.Distance(transform.position, TeleportTestCursor.transform.position) < MaxDistance)
        {
            TeleportTestCursor.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (MoveBackward == true && Vector3.Distance(transform.position, TeleportTestCursor.transform.position) > 3)
        {

            TeleportTestCursor.transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        Cursor2_Location = new Vector3 (TeleportTestCursor.transform.position.x, Cursor2.transform.position.y, TeleportTestCursor.transform.position.z);
        Cursor2.transform.position = Cursor2_Location;
        
        
      

        
    }
}
