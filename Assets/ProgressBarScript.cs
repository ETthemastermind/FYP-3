using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public int ListLength;
    public GameObject ArrayLengthDebug;
    public GameObject ProgBar;
    public float ProgBarFullLength;

    // Start is called before the first frame update
    void Start()
    {
        ListLength = gameObject.GetComponent<SliderObject>().DisplayBoards.Length;
        ArrayLengthDebug.GetComponent<Text>().text = ListLength.ToString();
        ProgBarFullLength = ProgBar.GetComponent<RectTransform>().localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    
}
