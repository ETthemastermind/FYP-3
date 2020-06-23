using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGripping : MonoBehaviour
{
    public bool Gripping;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void _IsGripping()
    {
        Gripping = true;
    }

    public void _IsNotGripping()
    {
        Gripping = false;
    }

}
