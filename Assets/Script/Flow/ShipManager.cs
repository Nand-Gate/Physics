using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public float createWidthPos;
    public float createTime;
    public Ship baseShip;

    private bool nowCreate;
    private Ship createShip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateShip();
        }
    }
    public void CreateShip()
    {
        if (nowCreate) return;
        GameObject beforeShip = null;
        if (createShip)beforeShip = createShip.gameObject;
        createShip = Instantiate(baseShip, Vector3.right * createWidthPos, Quaternion.identity);
        createShip.transform.DOMove(Vector3.zero, createTime);
        if (beforeShip) beforeShip.transform.DOMove(beforeShip.transform.position + Vector3.left * createWidthPos, createTime).OnComplete(() => Destroy(beforeShip));
    }
}
