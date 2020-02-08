using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssignInformation : MonoBehaviour
{

    public GameObject InformationDump;
    public int FirstLine;
    public int LastLine;
    private int CurrentLine;
    private string  Info;
    public List<string> RelevantInfo;
    public AudioClip[] AudioInfo;
    public string[] keywords;

    public bool ActiveArtefact = false;
    


    // Start is called before the first frame update
    void Start()
    {
        if (ActiveArtefact == true)
        {
            CurrentLine = FirstLine;
            while (CurrentLine != LastLine + 1)
            {
                Info = InformationDump.GetComponent<InformationDump>().textLines[CurrentLine];
                RelevantInfo.Add(Info);
                CurrentLine += 1;

            }



        }
        
        
        

        
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
