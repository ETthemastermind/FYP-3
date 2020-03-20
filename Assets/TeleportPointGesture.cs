using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TeleportPointGesture : MonoBehaviour
{
    public bool IsPointing;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPointing == true)
        {
            gameObject.GetComponent<TeleportArc>().Show();

        }
    }

    public void GestureActive()
    {
        IsPointing = true;
        Debug.Log("Teleport Gesture Active");
    }
    public void GestureInactive()
    {
        IsPointing = false;
        Debug.Log("Teleport Gesture Inactive");
    }
}
