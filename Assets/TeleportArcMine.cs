using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArcMine : MonoBehaviour   //http://wiki.unity3d.com/index.php/Trajectory_Simulation
{ 
    public GameObject Cube;
    public GameObject OtherCube;
    public Vector3 Midpoint;
    public LineRenderer Lr;
    public Vector3[] ArcPos;
    public Vector3[] ArcPoints;

    public int ArcResoltuion;


    public int SegmentCount;
    public float segmentScale;
    // Start is called before the first frame update
    void Start()
    {

        Lr = gameObject.GetComponent<LineRenderer>();
        Lr.SetVertexCount(ArcResoltuion);

    }

    // Update is called once per frame
    void Update()
    {

        /*
        ArcPos[0] = Cube.transform.position;
        ArcPos[2] = OtherCube.transform.position;
        Vector3 Midpoint = (ArcPos[0] + ArcPos[2]) / 2;
        float Midpoint_Y = (Cube.transform.position.y + Midpoint.y) / 2;
        Midpoint = new Vector3(Midpoint.x, Midpoint_Y, Midpoint.z);
        



        Lr.SetPosition(0, ArcPos[0]);
        Lr.SetPosition(1, Midpoint);
        Lr.SetPosition(2, ArcPos[2]);
        */
    


    }

    
}
