using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptOutOfTutorial : MonoBehaviour
{
    public GameObject ModalityController;
    public bool PlayerInTrigger;


    public GameObject Tutorial_VR;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerInTrigger = true;
        //Tutorial_VR.GetComponent<TutorialController>().OptedOutOfTutorial();
        Destroy(this);
    }
}
