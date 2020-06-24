using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookTelemetrySystem : MonoBehaviour
{
    public string[] DataLog;
    public GameObject MasterTelemetrySystem;

    public GameObject Artefact;
    public string ArtefactName;
    public string TypeOfArtefact;
    // Start is called before the first frame update
    void Start()
    {
        MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PushData(string TypeOfInteractionUsed, string TimeStamp_Started, string InteractionCompleted, string TimeStamp2)
    {
        DataLog[0] = ArtefactName;
        DataLog[1] = TypeOfArtefact;
        DataLog[2] = TypeOfInteractionUsed;
        DataLog[3] = TimeStamp_Started;
        DataLog[4] = InteractionCompleted;
        DataLog[5] = TimeStamp2;

        MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry(DataLog);
    }
    
}
