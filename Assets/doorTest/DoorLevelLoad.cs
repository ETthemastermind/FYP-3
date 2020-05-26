using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelLoad : MonoBehaviour
{
    public bool OpenDoor;
    public GameObject door;
    public GameObject Room;
    // Start is called before the first frame update
    void Start()
    {
        Room.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenDoor == true && Room.active == false)
        {
            gameObject.transform.Rotate(new Vector3 (0f, 90f, 0f));

            Room.SetActive(true);

            

        }

        
    }
}
