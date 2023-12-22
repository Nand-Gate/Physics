using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 vec;

    private bool canMove = false;
    private Transform mytrans;
    void Start()
    {
        mytrans = transform;
    }
    public void SetActivate(bool v)
    {
        canMove = v;
    }
    void Update()
    {
        if (canMove)
        {
            mytrans.Translate(vec * Time.deltaTime);
        }
    }
}
