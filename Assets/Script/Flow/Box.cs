using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class Box : MonoBehaviour
{
    public bool setted = false;
    public string shiptag = "Ship";

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != shiptag) return;
        tag = shiptag;
        setted = true;
    }
}
