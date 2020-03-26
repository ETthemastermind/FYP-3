using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand_Rot : MonoBehaviour
{
    public GameObject VRHand_Left;
    public GameObject DebugSphere;

    public Vector3 MinHandRot;
    public Vector3 MaxHandRot;
    // Start is called before the first frame update
    void Start()
    {
        VRHand_Left = GameObject.FindGameObjectWithTag("VR_LeftHand");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(VRHand_Left.transform.rotation.z);
        if (VRHand_Left.transform.rotation.z > 0.6f && VRHand_Left.transform.rotation.z < 0.8f)
        {
            DebugSphere.GetComponent<Renderer>().material.color = Color.red;

        }

        else
        {
            DebugSphere.GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
