using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortraitShowKeywords : MonoBehaviour
{
    public TMP_Text Keyword1;
    public TMP_Text Keyword2;
    public TMP_Text Keyword3;
    public TMP_Text Keyword4;
    // Start is called before the first frame update
    void Start()
    {
        Keyword1.text = gameObject.GetComponent<AssignInformation>().keywords[0];
        Keyword2.text = gameObject.GetComponent<AssignInformation>().keywords[1];
        Keyword3.text = gameObject.GetComponent<AssignInformation>().keywords[2];
        Keyword4.text = gameObject.GetComponent<AssignInformation>().keywords[3];

        Keyword1.transform.parent.GetComponent<AudioInfo>().Information = gameObject.GetComponent<AssignInformation>().AudioInfo[0];
        Keyword2.transform.parent.GetComponent<AudioInfo>().Information = gameObject.GetComponent<AssignInformation>().AudioInfo[1];
        Keyword3.transform.parent.GetComponent<AudioInfo>().Information = gameObject.GetComponent<AssignInformation>().AudioInfo[2];
        Keyword4.transform.parent.GetComponent<AudioInfo>().Information = gameObject.GetComponent<AssignInformation>().AudioInfo[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
