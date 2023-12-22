using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysyicsTest : MonoBehaviour
{
    public float power = 19.6f;

    private float timer;

    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * power;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Debug.Log(rb.velocity + "|" + timer + "|" + transform.position);
    }
}
