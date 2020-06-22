using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TelemetrySystemV2 : MonoBehaviour
{

    public string FilePath;
    public string TestDataLog;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        FilePath = Application.persistentDataPath + "/Telemetry.txt";
        StreamWriter writer = new StreamWriter(FilePath, false);
        writer.WriteLine("Spin my nipple nuts and send me to alaska");
        writer.Close();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEntry(string[] DataLog)
    {


    }
}
