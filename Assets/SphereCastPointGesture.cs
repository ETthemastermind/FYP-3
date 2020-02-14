using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereCastPointGesture : MonoBehaviour
{
    public bool _IsPointing = false;

    public GameObject FingerTip;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public GameObject CurrentHitObject;
    private float CurrentHitDistance;

    public GameObject KeywordObject;


    public LineRenderer LR;
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        LR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsPointing == true)
        {
            RaycastHit ObjectHit;
            LR.SetPosition(0,FingerTip.transform.position);
            
            if (Physics.SphereCast(FingerTip.transform.position, sphereRadius, FingerTip.transform.forward, out ObjectHit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
            {
                CurrentHitObject = ObjectHit.transform.gameObject;
                CurrentHitDistance = ObjectHit.distance;
                LR.SetPosition(1, ObjectHit.point);
                if (CurrentHitObject.gameObject.tag == "Keyword")
                {
                    KeywordObject = CurrentHitObject.transform.gameObject;
                    KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
                }
            }
            else
            {
                CurrentHitDistance = maxDistance;
                CurrentHitObject = null;
                KeywordObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                KeywordObject = null;
            }

        }
    }

    public void IsPointing()
    {
        Debug.Log("Player started pointing");
        _IsPointing = true;
        LR.enabled = true;
    }

    public void IsNotPointing()
    {
        Debug.Log("Player stopped pointing");
        _IsPointing = false;
        LR.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(FingerTip.transform.position, FingerTip.transform.position + FingerTip.transform.forward * CurrentHitDistance);
        Gizmos.DrawWireSphere(FingerTip.transform.position + FingerTip.transform.forward * CurrentHitDistance, sphereRadius);
    }
}
