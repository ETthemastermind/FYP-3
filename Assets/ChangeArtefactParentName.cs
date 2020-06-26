using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArtefactParentName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = gameObject.transform.GetChild(0).gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
