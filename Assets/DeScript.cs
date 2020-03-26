using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeScript : MonoBehaviour
{
    public GameObject VR_LeftHand;
    public GameObject VR_RightHand;
    public LineRenderer LR;
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LR.SetPosition(0, VR_LeftHand.transform.position);
        LR.SetPosition(1, VR_RightHand.transform.position);
    }
}
