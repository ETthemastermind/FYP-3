using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
public class TelemetrySystem : MonoBehaviour
{

    public string[] TestArray;
    public bool TestRunAddEntry;
    public string[] GatheredData;
    public string LogToEnter;
    
    public StreamWriter file;

    public string[] DemographicInfo;
    

    public TextAsset DemographicTelemetryFile;
    public string DTpath;
    public string[] DemographicHeaders;
    public TextAsset PortraitTelemetryFile; //variables for Portrait Telemetry
    public string Ppath;
    public string[] PortraitHeaders;
    public TextAsset PickUpArtefactTelemetryFile;
    public string PUApath;
    public string[] PUAHeaders;
    public TextAsset DioramaTelemetryFile;
    public string Dpath;
    public string[] DioramaHeaders;
    public TextAsset SliderTelemetryFile;
    public string Spath;
    public string[] SliderHeaders;





    // Start is called before the first frame update#
    private void Awake()
    {
        DemographicInfo[2] = System.DateTime.Now.ToLongTimeString();
    }
    public void OnApplicationQuit() //on application quit, might not need this
    {
        Debug.Log("Application Ended");
        DemographicInfo[3] = System.DateTime.Now.ToLongTimeString();
        AddEntry(DemographicInfo);

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DTpath = AssetDatabase.GetAssetPath(DemographicTelemetryFile); //get the path of the file
        Ppath = AssetDatabase.GetAssetPath(PortraitTelemetryFile); //get the path of the file
        PUApath = AssetDatabase.GetAssetPath(PickUpArtefactTelemetryFile); //get the path of the file
        Dpath = AssetDatabase.GetAssetPath(DioramaTelemetryFile); //get the path of the file
        Spath = AssetDatabase.GetAssetPath(SliderTelemetryFile); //get the path of the file
        File.WriteAllText(DTpath, ""); //clear the file before use
        File.WriteAllText(Ppath, ""); //clear the file before use
        File.WriteAllText(PUApath, ""); //clear the file before use
        File.WriteAllText(Dpath, ""); //clear the file before use
        File.WriteAllText(Spath, ""); //clear the file before use
        /*
        for (int h = 0; h < Headers.Length; h++) //adds headers as the first line of the txt file
        {
            string CurrentEntry = Headers[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file = new StreamWriter(path, true);
        Debug.Log("stream writer");
        

        file.WriteLine(LogToEnter); //write data to a line
        file.Close();

        Debug.Log("Data Added");
        */
        //AddEntry(DemographicInfo);
        


        LogToEnter = "";
        //add headers for portrait telemetry file================================================
        for (int h = 0; h < PortraitHeaders.Length; h++)
        {
            string CurrentEntry = PortraitHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file = new StreamWriter(Ppath, true);
        Debug.Log("stream writer");
        file.WriteLine(LogToEnter);
        file.Close();

        LogToEnter = "";
        //add headers for slider telemetry file================================================
        for (int h = 0; h < SliderHeaders.Length; h++)
        {
            string CurrentEntry = SliderHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file1 = new StreamWriter(Spath, true);
        Debug.Log("stream writer");
        file1.WriteLine(LogToEnter);
        file1.Close();


        LogToEnter = "";
        //add Headers for PickUpArtefact telemetry file===============================================
        for (int h = 0; h < PUAHeaders.Length; h++)
        {
            string CurrentEntry = PUAHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file2 = new StreamWriter(PUApath, true);
        Debug.Log("stream writer");
        file2.WriteLine(LogToEnter);
        file2.Close();


        LogToEnter = "";
        //add headers for Diorama Telemetry=======================================
        for (int h = 0; h < DioramaHeaders.Length; h++)
        {
            string CurrentEntry = DioramaHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file3 = new StreamWriter(Dpath, true);
        Debug.Log("stream writer");
        file3.WriteLine(LogToEnter);
        file3.Close();


    }

    // Update is called once per frame
    void Update()
    {
        if (TestRunAddEntry == true) //debug to test adding data
        {
            //TestAddEntry();
            TestRunAddEntry = false;
        }
    }

    

    public void AddEntry(string[] DataLog) //array gets passed in from the subtelemetry systems
    {
        LogToEnter = "";
        Debug.Log("Add Entry"); //debug to make sure the method passes

        for (int d = 0; d < 2; d++) //adds the demographic data to be entered to the line
        {
            string CurrentEntry = DemographicInfo[d] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        
        for (int i = 0; i < DataLog.Length; i++)
        {
            string CurrentEntry = DataLog[i] + ",";
            LogToEnter += CurrentEntry;
        }


        if (DataLog[1] == "Portrait Exhibit")
        {
            Debug.Log("Pushing to Portrait File");
            StreamWriter file = new StreamWriter(Ppath, true);
            file.WriteLine(LogToEnter); //write data to a line
            file.Close();
        }
        else if (DataLog[1] == "PickUp Artefacts")
        {
            Debug.Log("Pushing to PickUp File");
            StreamWriter file = new StreamWriter(PUApath, true);
            file.WriteLine(LogToEnter); //write data to a line
            file.Close();
        }

        else if (DataLog[1] == "Diorama")
        {
            Debug.Log("Pushing to Diorama File");
            StreamWriter file = new StreamWriter(Dpath, true);
            file.WriteLine(LogToEnter); //write data to a line
            file.Close();
        }
        else if (DataLog[1] == "Slider Exhibit")
        {
            Debug.Log("Pushing to Slider File");
            StreamWriter file = new StreamWriter(Spath, true);
            file.WriteLine(LogToEnter); //write data to a line
            file.Close();
        }

        else
        {
            Debug.Log("Pushing to Demographic File");
            StreamWriter file = new StreamWriter(DTpath, true);
            file.WriteLine(LogToEnter); //write data to a line
            file.Close();
        }
    }

    /*

    public void TestAddEntry() //array gets passed in from the subtelemetry systems //https://www.youtube.com/watch?v=vDpww7HsdnM 
    {
        LogToEnter = "";
        Debug.Log("Add Entry"); //debug to make sure the method passes
        for (int i = 0; i < TestArray.Length; i++) //for each entry in the passed array, end goal is to put the data in a format that can be used as a CSV
        {
            //Debug.Log(DataLog[i]);
            string CurrentEntry = TestArray[i] + ","; //make the data from array[i] suitable for a CSV
            LogToEnter = LogToEnter + CurrentEntry; //add the current entry to the full entry

        }


        
        
        StreamWriter file = new StreamWriter(path, true);
        Debug.Log("stream writer");

        
        file.WriteLine(LogToEnter); //write data to a line
        file.Close();

        Debug.Log("Data Added");


        
        

        
    }#
    */
}
