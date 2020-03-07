using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIGif : MonoBehaviour
{
    public Sprite[] Frames;
    public float WaitTime = 1;
    public float CurrentTime;
    public int StartFrame = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = WaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        CurrentTime -= Time.deltaTime;

        if (CurrentTime < 0)
        {
            StartFrame += 1;
            if (StartFrame >= Frames.Length)
            {
                StartFrame = 0;

            }
            gameObject.GetComponent<Image>().sprite = (Frames[StartFrame]);
            CurrentTime = WaitTime;
        }
        
    }
}
