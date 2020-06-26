using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class TelemetrySystemV2 : MonoBehaviour
{

    public bool TelemetryActive;
    public string[] TestDataLog;
    public bool TestSaveData;
    public string[] DemographicInfo;

    public string Identifier;
    public string LogToEnter;

    public string I_FileName;
    public string I_FilePath;
    public string[] I_Headings;

    public string D_FileName;
    public string D_FilePath;
    public string[] D_Headings;

    public string L_FileName;
    public string L_FilePath;
    public string[] L_Headings;
    public float X_TimePeriod;
    public string[] LocomotionInformation;

    public GameObject[] UserEntryBoxes;


    
    public string CurrentDate;
    public string CurrentTime;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Player = GameObject.FindGameObjectWithTag("Player");
        //CreateFiles();
        //string FileName = "/Test.csv";
        //InvokeRepeating("LocomotionInfo",0f,0.5f);

        






    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddEntry(string[] DataLog) //adds entry for interactio information
    {
        if (TelemetryActive == true)
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
            StreamWriter writer = new StreamWriter(I_FilePath, true);
            writer.WriteLine(LogToEnter);
            writer.Close();
            TestSaveData = false;

        }
        
    }

    public void CreateFiles()
    {

        System.Random _random = new System.Random();  //generates a user ID;
        char letter_1 = (char)_random.Next('A', 'Z');
        char letter_2 = (char)_random.Next('A', 'Z');
        char number_1 = (char)_random.Next('0', '9');
        char number_2 = (char)_random.Next('0', '9');
        char number_3 = (char)_random.Next('0', '9');
        char number_4 = (char)_random.Next('0', '9');

        Identifier = letter_1.ToString() + letter_2.ToString() + number_1.ToString() + number_2.ToString() + number_3.ToString() + number_4.ToString();
        UserEntryBoxes[0].GetComponent<TMP_InputField>().text = Identifier;
        


        CurrentDate = System.DateTime.Now.ToShortDateString();
        CurrentTime = System.DateTime.Now.ToLongTimeString();

        CurrentDate = CurrentDate.Replace("/", "-");
        CurrentTime = CurrentTime.Replace(":", "-");
        //creaing interaction telemetry
        I_FileName = "/" + Identifier + "Interaction_"+ CurrentDate + "_" + CurrentTime+"_" + ".csv";
        I_FilePath = Application.persistentDataPath + I_FileName;
        StreamWriter I_writer = new StreamWriter(I_FilePath, false);
        //writer.WriteLine("Spin my nipple nuts and send me to alaska"); debug to test 

        LogToEnter = "";
        Debug.Log("Creating Telemetry Headings");
        for (int H = 0; H < I_Headings.Length; H++)
        {

            LogToEnter += I_Headings[H] + ",";
        }

        I_writer.WriteLine(LogToEnter);
        I_writer.Close();

        //Creating Demographic telemetry

        D_FileName = "/" + Identifier + "Demographic_" + CurrentDate + "_" + CurrentTime + "_" + ".csv";
        D_FilePath = Application.persistentDataPath + D_FileName;
        StreamWriter D_writer = new StreamWriter(D_FilePath, false);
        //writer.WriteLine("Spin my nipple nuts and send me to alaska"); debug to test 

        LogToEnter = "";
        Debug.Log("Creating Demographic Headings");
        for (int H = 0; H < D_Headings.Length; H++)
        {

            LogToEnter += D_Headings[H] + ",";
        }

        D_writer.WriteLine(LogToEnter);
        D_writer.Close();

        //Creating Locomotion Telemetry

        L_FileName = "/" + Identifier + "Locomotion_" + CurrentDate + "_" + CurrentTime + "_" + ".csv";
        L_FilePath = Application.persistentDataPath + L_FileName;
        StreamWriter L_writer = new StreamWriter(L_FilePath, false);
        //writer.WriteLine("Spin my nipple nuts and send me to alaska"); debug to test 

        LogToEnter = "";
        Debug.Log("Creating Demographic Headings");
        for (int H = 0; H < L_Headings.Length; H++)
        {

            LogToEnter += L_Headings[H] + ",";
        }

        L_writer.WriteLine(LogToEnter);
        L_writer.Close();
    }

    public void OnLevelWasLoaded(int level)
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //gets the player when a scene is loaded
    }

    public void LocomotionInfo()
    {
        LocomotionInformation[0] = SceneManager.GetActiveScene().name;
        LocomotionInformation[1] = "Standard";
        LocomotionInformation[2] = Player.transform.position.ToString();
        LocomotionInformation[3] = Player.transform.rotation.eulerAngles.ToString();
        LocomotionInformation[4] = System.DateTime.Now.ToString("hh.mm.ss.ffffff");

        LocomotionInformation[2] = LocomotionInformation[2].Replace(",", "|");
        LocomotionInformation[3] = LocomotionInformation[2].Replace(",", "|");

        LogToEnter = ""; //clears the entry log
        Debug.Log("Add Entry");

        for (int i = 0; i < LocomotionInformation.Length; i++)
        {
            LogToEnter += LocomotionInformation[i] + ",";
        }

        //Debug.Log(LogToEnter);
        StreamWriter writer = new StreamWriter(L_FilePath, true);
        writer.WriteLine(LogToEnter);
        writer.Close();
        TestSaveData = false;

    }

    public void AddEntry_Demographic()
    {

        LogToEnter = ""; //clears the entry log
        Debug.Log("Add Entry");

        for (int i = 0; i < UserEntryBoxes.Length; i++)
        {
            LogToEnter += UserEntryBoxes[i].GetComponent<TMP_InputField>().text + ",";
        }
        DemographicInfo[1] = UserEntryBoxes[1].GetComponent<TMP_InputField>().text;
        Debug.Log("LogToEnter is: " + LogToEnter);
        StreamWriter writer = new StreamWriter(D_FilePath, true);
        writer.WriteLine(LogToEnter);
        writer.Close();
        InvokeRepeating("LocomotionInfo",0f,0.5f);

    }


}
