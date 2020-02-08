using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepad_Tutorial : MonoBehaviour
{

    Color lerpedColor = Color.white;
    public float number = 1;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ScriptActive");
        lerpedColor = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, number));
        Button.GetComponent<Renderer>().material.SetColor("_Color",lerpedColor);
    }
}
