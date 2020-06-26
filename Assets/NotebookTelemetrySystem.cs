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
    
    void Awake()
    {
        MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (MasterTelemetrySystem == null)
        {
            MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
        }
        
    }
    
    public void PushData(string TypeOfInteractionUsed)
    {
        DataLog[0] = ArtefactName;
        DataLog[1] = TypeOfArtefact;
        DataLog[2] = TypeOfInteractionUsed;
        

        MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry(DataLog);
    }
    
}
