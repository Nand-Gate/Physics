using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Cannon : MonoBehaviour
{
    public Rigidbody2D obj;
    public float power;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obj, transform.position, transform.rotation).velocity = transform.up * power;
        }
    }
}
