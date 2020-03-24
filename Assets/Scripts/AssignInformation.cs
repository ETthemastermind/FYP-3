using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssignInformation : MonoBehaviour  //general information recepticle for individual objects
{

    public GameObject InformationDump; //reference to the object that stores all of a rooms text based information
    public int FirstLine; //first line of information needed
    public int LastLine; //last line of information needed
    private int CurrentLine; //current line of information
    private string  Info; // line of information
    public List<string> RelevantInfo; // list of found information
    public AudioClip[] AudioInfo; //array of audio clips
    public string[] keywords; //array of keywords

    public bool ActiveArtefact = false; //had issues where lots of errors happened because there was no actual info to get
    


    // Start is called before the first frame update
    void Start()
    {
        if (ActiveArtefact == true)
        {
            CurrentLine = FirstLine; // changes current line int to the first line
            while (CurrentLine != LastLine + 1) //cycles through all the lines for each object (4)
            {
                Info = InformationDump.GetComponent<InformationDump>().textLines[CurrentLine]; //gets information line in the text file thats the same as the current line
                RelevantInfo.Add(Info); //adds found info to the list of the relevant information
                CurrentLine += 1; //increments the line

            }



        }
        
        
        

        
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
