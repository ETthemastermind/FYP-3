using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand_Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ObjectHit;
        if (Physics.Raycast(transform.position, transform.forward, out ObjectHit))
        {
            if (ObjectHit.transform.tag == "DirectionPlane")
            {
                Debug.Log(ObjectHit.transform.gameObject.name);
            }

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + transform.forward * 5f);
        
    }
}
