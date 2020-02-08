using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandsPage : MonoBehaviour
{
    public TMP_Text ArtefactName;
    public TMP_Text CommandOne;
    public TMP_Text CommandTwo;
    public TMP_Text CommandThree;
    public TMP_Text CommandFour;

    public GameObject SpeechController;
    public string[] FoundInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeechController.GetComponent<SmallObject_SpeechRec>().Artefact != null)
        {
            FoundInfo[0] = SpeechController.GetComponent<SmallObject_SpeechRec>().Artefact.gameObject.name;
            FoundInfo[1] = SpeechController.GetComponent<SmallObject_SpeechRec>().Keywords[0];
            FoundInfo[2] = SpeechController.GetComponent<SmallObject_SpeechRec>().Keywords[1];
            FoundInfo[3] = SpeechController.GetComponent<SmallObject_SpeechRec>().Keywords[2];
            FoundInfo[4] = SpeechController.GetComponent<SmallObject_SpeechRec>().Keywords[3];

            ArtefactName.text = FoundInfo[0];
            CommandOne.text = FoundInfo[1];
            CommandTwo.text = FoundInfo[2];
            CommandThree.text = FoundInfo[3];
            CommandFour.text = FoundInfo[4];
        }
        


        
    }
}
