using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour 
{
    public string LevelName; //name of the level to load
    public GameObject SpawnManager;
    public GameObject Spawner;
    public GameObject InteractRing;

    public static Vector3 PlayerReturnPoint;
    public GameObject Player;
    
   
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        LevelName = gameObject.GetComponent<SteamVR_LoadLevel>().levelName;
        SpawnManager = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractRing.GetComponent<AreaEntered>().PlayerInTrigger == true)
        {
            Spawner.SetActive(true);
        }

        else if (InteractRing.GetComponent<AreaEntered>().PlayerInTrigger == false)
        {
            Spawner.SetActive(false);
        }
                
    }

    public void OpenScene()
    {

        //PlayerSpawning.PlayerReturnPoint = Spawner;
        PlayerReturnPoint = Player.transform.position;
        Debug.Log(PlayerReturnPoint);
        SteamVR_LoadLevel.Begin(LevelName);
        /*
        SpawnPoint.GetComponent<PlayerSpawning>().SpawnMove();
        SpawnPoint.transform.position = InteractRing.transform.position;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SpawnManager.GetComponent<PlayerSpawning>().SavePosition();
        }
        
        SteamVR_LoadLevel.Begin(LevelName);
        */
    }
}
