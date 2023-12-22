using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Flower : MonoBehaviour
{
    public float piv_dis;
    public float objmass;
    public float watermass;
    public float objsize;
    public float height;
    public float waterHorizon;
    public float gravity;
    public float widthWaterResist;
    public bool debug;

    [SerializeField]private float forceCounter;
    private Transform tr;
    private Rigidbody2D rb;
    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        forceCounter = 0;
    }
    void FixedUpdate()
    {
        Flow();
    }
    public void Flow()
    {
        float dis = Mathf.Clamp( waterHorizon - tr.position.y + piv_dis,0,height);
        float mass = dis / height * objsize * watermass;
        float obj = objsize * objmass * gravity;
        float vec =  -obj;
        if(dis > 0 && rb.velocity.y < 0)
        {
            float y = rb.velocity.y;
            y *= -widthWaterResist;
            Force(y);
        }
        vec += mass * gravity;
        Force(vec);
        if(debug)Debug.Log(dis);
    }
    public void Force(float v)
    {
        rb.AddForce(Vector2.up * v, ForceMode2D.Force);
        forceCounter += v;
    }
}
