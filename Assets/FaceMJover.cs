using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMJover : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
}
