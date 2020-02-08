using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InformationDump : MonoBehaviour
{

    public TextAsset IntroInfo;
    public string[] textLines;
    // Start is called before the first frame update
    void Awake()
    {
        textLines = (IntroInfo.text.Split('\n'));
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
