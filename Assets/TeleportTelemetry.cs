using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTelemetry : MonoBehaviour
{
    public GameObject MasterTelemetrySystem;
    public string[] DataLog;
    public string ArtefactName = "VR+ Teleporting System";
    public string TypeOfArtefact = "VR+ Teleporting";
    // Start is called before the first frame update
    void Start()
    {
        MasterTelemetrySystem = GameObject.FindGameObjectWithTag("TelemetrySystem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushData(string TypeOfInteractionUsed)
    {
        DataLog[0] = ArtefactName;
        DataLog[1] = TypeOfArtefact;
        DataLog[2] = TypeOfInteractionUsed;
        DataLog[3] = System.DateTime.Now.ToString("hh.mm.ss.ffffff");


        if (MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().TelemetryActive == true)
        {
            MasterTelemetrySystem.GetComponent<TelemetrySystemV2>().AddEntry(DataLog);
            Debug.Log("Diorama Data Pushed");
        }


    }
}
