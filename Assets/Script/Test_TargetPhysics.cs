using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_TargetPhysics : MonoBehaviour
{
    private Transform b;
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Doing());
        }
        if(b != null)
        {
            if((b.position - transform.position).sqrMagnitude < 0.1)
            {
                Destroy(b.gameObject);
                Destroy(gameObject);
            }
        }
    }
    public IEnumerator Doing()
    {
        yield return new WaitForSeconds(1f);
        rb.gravityScale = 1;
        yield break;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        b = collision.transform;
    }
}
