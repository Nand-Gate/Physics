using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerocityShower : MonoBehaviour
{
    public Color xColor;
    public Color yColor;
    public Color vecColor;
    public SpriteRenderer verocityObj;
    public float powWidth;

    //[x,y,vec]
    private SpriteRenderer[] createSprite = new SpriteRenderer[3];
    private Transform[] createTrans = new Transform[3];

    private Transform mytrans;
    private Rigidbody2D rb = null;
    void Start()
    {
        mytrans = transform;
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        for(int i = 0;i < 3; i++)
        {
            createSprite[i] = Instantiate(verocityObj);
            createSprite[i].sortingOrder = sp.sortingOrder + 1;
            createTrans[i] = createSprite[i].transform;
        }
        createSprite[0].color = xColor;
        createSprite[1].color = yColor;
        createSprite[2].color = vecColor;
    }
    void Update()
    {
        Vector3 pos = mytrans.position;
        Vector2 vec = rb.velocity;
        createTrans[0].localPosition = pos + new Vector3(vec.x / 2f, 0, 0);
        createTrans[1].localPosition = pos + new Vector3(0,vec.y / 2f,0);
        createTrans[2].localPosition = pos + new Vector3(vec.x / 2f, vec.y / 2f, 0);
        createTrans[2].rotation = Quaternion.LookRotation(Vector3.forward, vec);
        createTrans[0].localScale = new Vector3(vec.x, powWidth, 1);
        createTrans[1].localScale = new Vector3(powWidth, vec.y, 1);
        createTrans[2].localScale = new Vector3(powWidth,vec.magnitude, 1);
    }
}
