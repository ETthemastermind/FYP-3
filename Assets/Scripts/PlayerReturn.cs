using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReturn : MonoBehaviour
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
}
