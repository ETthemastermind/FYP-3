using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForeignPolicyAssign : MonoBehaviour
{
    public GameObject InformationDump;
    public int ChosenLine;    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Text>().text = InformationDump.GetComponent<InformationDump>().textLines[ChosenLine];

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //gameObject.GetComponent<Text>().text = InformationDump.GetComponent<InformationDump>().textLines[ChosenLine];
    }
}
