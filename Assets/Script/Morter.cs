using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morter : MonoBehaviour
{
    public float pow;

    private bool canRote = false;
    private Transform mytrans;
    void Start()
    {
        mytrans = transform;
    }
    public void SetActivate(bool v)
    {
        canRote = v;
    }
    void Update()
    {
        if (canRote)
        {
            mytrans.Rotate(0, 0, pow * Time.deltaTime);
        }
    }
}
