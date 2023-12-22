using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionMover : MonoBehaviour
{
    public float moveSpeed;
    public Transform human;

    private bool clicked;
    private Rigidbody2D h_rb;
    private Rigidbody2D rb;
    void Start()
    {
        h_rb = human.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!clicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                human.parent = null;
                clicked = true;
                rb.velocity = Vector2.right * Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
            }
            rb.velocity = Vector2.right * moveSpeed;
            h_rb.velocity = Vector2.right * moveSpeed;
        }
    }
}
