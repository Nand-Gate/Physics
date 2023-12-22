using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameeraMover : MonoBehaviour
{
    public float movePer;
    public Transform target;

    private Vector3 re;
    private Transform mytrans;
    void Start()
    {
        mytrans = transform;
        re = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mypos = mytrans.position;
        Vector3 targetpos = target.position;
        targetpos.z = mypos.z;
        Vector3 vec = Vector3.SmoothDamp(mypos, targetpos,ref re ,movePer);
        mytrans.position = vec;
    }
}
