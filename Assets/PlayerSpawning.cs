using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSpawning : MonoBehaviour
{
    public Vector3 PlayerReturnPoint;
    public bool playerSpawnedOnPoint = false;
    public GameObject PlayerSpawnpoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerSpawnpoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
            if (playerSpawnedOnPoint == false)
            {
                playerSpawnedOnPoint = true;
            }
            else
            {
                Player.transform.position = PlayerReturnPoint;
            }


        }
        
        
        
        
        /*
        int NumOfSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawn").Length;
        GameObject[] Spawners = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        DontDestroyOnLoad(gameObject);
        /*
        if (NumOfSpawners != 1)
        {
            Destroy(this.gameObject);

        }

        else
        {
            DontDestroyOnLoad(gameObject);

        }
        */





    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnMove()
    {
        
    }
}
