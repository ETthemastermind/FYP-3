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
    public string LogToEnter;
    public string path;
    public StreamWriter file;

    public string[] DemographicInfo;
    public string[] Headers;

    public TextAsset TF;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        path = AssetDatabase.GetAssetPath(TF); //get the path of the file
        File.WriteAllText(path, ""); //clear the file before use
        /*
        for (int h = 0; h < Headers.Length; h++) //adds headers as the first line of the txt file
        {
            string CurrentEntry = Headers[h] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        StreamWriter file = new StreamWriter(path, true);
        Debug.Log("stream writer");
        */

        file.WriteLine(LogToEnter); //write data to a line
        file.Close();

        Debug.Log("Data Added");




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

    public void OnApplicationQuit() //on application quit, might not need this
    {
        Debug.Log("Application Ended");
        
    }

    public void AddEntry(string[] DataLog) //array gets passed in from the subtelemetry systems
    {
        LogToEnter = "";
        Debug.Log("Add Entry"); //debug to make sure the method passes

        for (int d = 0; d < DemographicInfo.Length; d++) //adds the demographic data to be entered to the line
        {
            string CurrentEntry = DemographicInfo[d] + ",";
            LogToEnter = LogToEnter + CurrentEntry;
        }
        for (int i = 0; i < DataLog.Length; i++) //for each entry in the passed array, end goal is to put the data in a format that can be used as a CSV
        {
            //Debug.Log(DataLog[i]);
            string CurrentEntry = DataLog[i] + ","; //make the data from array[i] suitable for a CSV
            LogToEnter = LogToEnter + CurrentEntry; //add the current entry to the full entry

        }

        StreamWriter file = new StreamWriter(path, true);
        Debug.Log("stream writer");


        file.WriteLine(LogToEnter); //write data to a line
        file.Close();

        Debug.Log("Data Added");
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
