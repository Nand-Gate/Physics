using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragger : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    public Transform target;

    private Vector3 startPos;
    private Vector2 startPointerPos;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 vec = eventData.position - startPointerPos;
        target.position = startPos + vec;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StageNode.nowSelectNode = null;
        startPos = target.position;
        startPointerPos = eventData.position;
    }
}
