using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LoadLevel : MonoBehaviour
{
    public string LevelName;
    public GameObject SpawnPoint;
    
   
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        LevelName = gameObject.GetComponent<SteamVR_LoadLevel>().levelName;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene()
    {

        //SpawnPoint.GetComponent<PlayerSpawning>().SpawnMove();
        //SpawnPoint.transform.position = InteractRing.transform.position;
        
        SteamVR_LoadLevel.Begin(LevelName);

    }
}
