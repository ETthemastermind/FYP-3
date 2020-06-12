using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandsPage : MonoBehaviour
{
    public TMP_Text ArtefactName_CMD;   //reference to the UI components on the guide book
    public TMP_Text ArtefactName_INFO;
    public TMP_Text CommandOne;
    public TMP_Text CommandTwo;
    public TMP_Text CommandThree;
    public TMP_Text CommandFour;

    public GameObject SpeechController; //reference to the speech controller object on the player
    public string[] FoundInfo; //string array of the found information to present on the pages

    public string _ActiveCommand;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeechController.GetComponent<SmallObject_SpeechRec1>().Artefact != null)
        {
            FoundInfo[0] = SpeechController.GetComponent<SmallObject_SpeechRec1>().Artefact.gameObject.name; //finds all the relevant info from the speech controller
            FoundInfo[1] = SpeechController.GetComponent<SmallObject_SpeechRec1>().Keywords[0];
            FoundInfo[2] = SpeechController.GetComponent<SmallObject_SpeechRec1>().Keywords[1];
            FoundInfo[3] = SpeechController.GetComponent<SmallObject_SpeechRec1>().Keywords[2];
            FoundInfo[4] = SpeechController.GetComponent<SmallObject_SpeechRec1>().Keywords[3];

            ArtefactName_CMD.text = FoundInfo[0]; //assigns the found information
            ArtefactName_INFO.text = FoundInfo[0];
            CommandOne.text = FoundInfo[1];
            CommandTwo.text = FoundInfo[2];
            CommandThree.text = FoundInfo[3];
            CommandFour.text = FoundInfo[4];
        }
        else if (SpeechController.GetComponent<SmallObject_SpeechRec1>().Artefact = null) { }





    }
}
