using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Dial : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public int value;
    public int valueAddMonoAngle;

    private int baseValue;
    private int firstAngle;
    private bool moved;
    private Transform mytrans;
    void Start()
    {
        mytrans = transform;
    }
    void Update()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        baseValue = value;
        firstAngle = (int)((720 + Quaternion.LookRotation(Vector3.forward, eventData.position - (Vector2)mytrans.position).eulerAngles.z) % 360);
    }
    public void OnDrag(PointerEventData eventData)
    {
        int angle = (int)((720 + Quaternion.LookRotation(Vector3.forward, eventData.position - (Vector2)mytrans.position).eulerAngles.z) % 360);
        if(!moved && angle != firstAngle)
        {
            moved = true;
        }
        if(moved && angle == firstAngle)
        {
            baseValue = value;
            moved = false;
        }
        value = baseValue + (int)((360 + (angle - firstAngle)) % 360 / valueAddMonoAngle);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        moved = false;
    }
}
