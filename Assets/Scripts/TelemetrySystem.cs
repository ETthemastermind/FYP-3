using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using UnityEditor;
public class TelemetrySystem : MonoBehaviour
{

    public string[] TestArray;
    public bool TestRunAddEntry;
    public string[] GatheredData;
    public string LogToEnter; //data string that gets written to .txt files
    
    

    public string[] DemographicInfo; //array for the demographic info


    
    public string DTpath;  //references for the path to the files and array of headers for the files
    public string[] DemographicHeaders;
    
    public string Ppath;
    public string[] PortraitHeaders;
    
    public string PUApath;
    public string[] PUAHeaders;
    
    public string Dpath;
    public string[] DioramaHeaders;
    
    public string Spath;
    public string[] SliderHeaders;





   
    private void Awake()
    {
        DemographicInfo[2] = System.DateTime.Now.ToLongTimeString(); //gets the timestamp for musuem started
    }
    public void OnApplicationQuit() //
    {
        Debug.Log("Application Ended");
        DemographicInfo[3] = System.DateTime.Now.ToLongTimeString(); //gets the timestamp for museum ended
        AddEntry(DemographicInfo); //adds data to the relevant file

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SaveData();

        Debug.Log(Application.persistentDataPath);
        //LoadData();

        /*
        DTpath = Application.persistentDataPath + "/../../DemographicTelemetry.txt"; //in the streamingassets folder
        Ppath = Application.persistentDataPath + "/../../PortraitTelemetryFile.txt";
        PUApath = Application.persistentDataPath + "/../../PickUpArtefactTelemetryFile.txt"; ; //get the path of the file
        Dpath = Application.persistentDataPath + "/../../DioramaTelemetry.txt" ; //get the path of the file
        Spath = Application.persistentDataPath + "/../../SliderTelemetryFile.txt"; //get the path of the file
        
        
        StreamWriter file = new StreamWriter(DTpath); //testing, trying to get the data to push to the file
        file.WriteLine(DTpath, "Test"); //tried both of these didnt work
        file.Write(DTpath, "test");
        file.Flush();
        file.Close();
        Debug.Log("Data Done a Thing");

        /*
        BinaryFormatter Bf = new BinaryFormatter();
        //string path = Application.persistentDataPath + "DemographicTelemetry.txt";
        FileStream stream = new FileStream(path, FileMode.Append);
        Bf.Serialize(stream, "Testing");
        stream.Close();
        Debug.Log("Data tried another thing");
        */
        File.WriteAllText(Ppath, ""); //clear the file before use
        File.WriteAllText(PUApath, ""); //clear the file before use
        File.WriteAllText(Dpath, ""); //clear the file before use
        File.WriteAllText(Spath, ""); //clear the file before use
       
        
        LogToEnter = "";
        //add headers for portrait telemetry file================================================

        BinaryFormatter bf = new BinaryFormatter();
        for (int h = 0; h < PortraitHeaders.Length; h++)
        {
            string CurrentEntry = PortraitHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        if (File.Exists(Application.persistentDataPath + "/PortraitTelemetry.txt"))
        {
            File.Delete(Application.persistentDataPath + "/PortraitTelemetry.txt");
        }
        else
        {
            File.Create(Application.persistentDataPath + "/PortraitTelemetry.txt");
        }

        //bf.Serialize()

       
        /*
        StreamWriter PHeaders = new StreamWriter(Ppath, true);
        Debug.Log("stream writer");
        PHeaders.WriteLine(LogToEnter);
        PHeaders.Close();

        LogToEnter = "";
        */
        //add headers for slider telemetry file================================================
        for (int h = 0; h < SliderHeaders.Length; h++)
        {
            string CurrentEntry = SliderHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter SHeaders = new StreamWriter(Spath, true);
        Debug.Log("stream writer");
        SHeaders.WriteLine(LogToEnter);
        SHeaders.Close();

        LogToEnter = "";
        //add Headers for PickUpArtefact telemetry file===============================================
        for (int h = 0; h < PUAHeaders.Length; h++)
        {
            string CurrentEntry = PUAHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter PUA_Headers = new StreamWriter(PUApath, true);
        Debug.Log("stream writer");
        PUA_Headers.WriteLine(LogToEnter);
        PUA_Headers.Close();


        LogToEnter = "";
        //add headers for Diorama Telemetry=======================================
        for (int h = 0; h < DioramaHeaders.Length; h++)
        {
            string CurrentEntry = DioramaHeaders[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter DHeaders = new StreamWriter(Dpath, true);
        Debug.Log("stream writer");
        DHeaders.WriteLine(LogToEnter);
        DHeaders.Close();
        

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
        Debug.Log(DataLog[2]);
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


        if (DataLog[1] == "Portrait Exhibit") //changes file based on where 
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


        Debug.Log("Data Added");
    }


    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/TestText.txt");
        Debug.Log("File Created");
        bf.Serialize(fs, "Test Text");
        fs.Close();
        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        if (File.Exists((Application.persistentDataPath + "/TestText.txt")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open((Application.persistentDataPath + "/TestText.txt"), FileMode.Open);
            Debug.Log(fs.ToString());
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
