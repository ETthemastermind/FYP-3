using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LMPalmDebug : MonoBehaviour
{
    public GameObject Palm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "X: " + Palm.transform.localRotation.x + "\nY:" + Palm.transform.localRotation.y + "\nZ:" + Palm.transform.localRotation.z + "\nW: " + Palm.transform.localRotation.w;
    }
}
