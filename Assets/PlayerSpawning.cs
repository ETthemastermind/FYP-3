using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerSpawning : MonoBehaviour
{
    public static bool FirstTimeSpawn = true;
    private void Start()
    {
        if (FirstTimeSpawn == true)
        {
            FirstTimeSpawn = false;

        }

        else if (FirstTimeSpawn == false)
        {
            gameObject.SetActive(false);
        }
        
    }


}
