using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TelemetrySystemV2 : MonoBehaviour
{

    public string FilePath;
    public string[] TestDataLog;
    public bool TestSaveData;
    public string[] DemographicInfo;
    public string[] Headings;

    public string LogToEnter;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        FilePath = Application.persistentDataPath + "/Telemetry.csv";
        StreamWriter writer = new StreamWriter(FilePath, false);
        //writer.WriteLine("Spin my nipple nuts and send me to alaska"); debug to test 

        LogToEnter = "";
        Debug.Log("Creating Telemetry Headings");
        for (int H = 0; H < Headings.Length; H++)
        {
            
            LogToEnter += Headings[H] + ",";
        }

        writer.WriteLine(LogToEnter);
        writer.Close();

    }

    // Update is called once per frame
    void Update()
    {
        if (TestSaveData == true)
        {
            AddEntry(TestDataLog);
        }
    }

    public void AddEntry(string[] DataLog)
    {
        LogToEnter = ""; //clears the entry log
        Debug.Log("Add Entry");
        
        for (int d = 0; d < 2; d++) //for the first two entries in demographic info (identifier and version)
        {
            Debug.Log("Adding relevant demographic info");
            LogToEnter += DemographicInfo[d] + ",";
        }

        for (int i = 0; i < DataLog.Length; i++)
        {
            LogToEnter += DataLog[i] + ",";
        }

        Debug.Log(LogToEnter);
        StreamWriter writer = new StreamWriter(FilePath, true);
        writer.WriteLine(LogToEnter);
        writer.Close();
        TestSaveData = false;
    }
}
