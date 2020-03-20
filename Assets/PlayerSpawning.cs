using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerSpawning : MonoBehaviour
{
    private void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

    private void OnDestroy()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SavedPositionManager.savedPositions[sceneIndex] = transform.position;
    }
    /*
    //public static GameObject PlayerReturnPoint;
    public static bool FirstSpawnInstance = true;
    public GameObject FirstSpawnPoint;
    public GameObject Player;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (FirstSpawnInstance == true)
        {
            FirstSpawnInstance = false;
            
        }

        else if (FirstSpawnInstance == false)
        {
            FirstSpawnPoint.SetActive(false);
            Player.transform.position =(LoadLevel.PlayerReturnPoint);
        }
    }
    public void NewSpawnPoint()
    {
        

    }

    
    public GameObject PlayerSpawnPoint;
    static public Vector3 SavedPosition;
    static public bool FirstSpawnInstance = true;
    public GameObject Player;
  
    // Start is called before the first frame update

    
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (FirstSpawnInstance == true)
        {

            FirstSpawnInstance = false;

        }
        else if (FirstSpawnInstance == false)
        {
            PlayerSpawnPoint.transform.position = SavedPosition;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void SavePosition()
    {
        PlayerSpawnPoint.transform.position = Player.transform.position;
        SavedPosition = PlayerSpawnPoint.transform.position;
        
    }

    */


}
