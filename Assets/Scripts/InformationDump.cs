using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InformationDump : MonoBehaviour
{

    public TextAsset IntroInfo; //reference to the text file of information
    public string[] textLines; //big boi array of text lines
    // Start is called before the first frame update
    void Awake()
    {
        textLines = (IntroInfo.text.Split('\n')); //splits the text asset into lines and assings each one to a value in the array
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
