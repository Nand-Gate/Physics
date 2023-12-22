using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;

public class TextArea_Handle : MonoBehaviour,IPointerClickHandler
{
    public float moveTime;
    public float moveDis;
    public Transform target;

    private bool nowOpen = true;
    private bool canClick = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public async void OnPointerClick(PointerEventData eventData)
    {
        if (!canClick) return;
        Vector3 vec = target.position;
        if (nowOpen)
        {
            nowOpen = false;
            vec += Vector3.up * moveDis;
        }
        else
        {
            nowOpen = true;
            vec += Vector3.down * moveDis;
        }
        canClick = false;
        await target.DOMove(vec, moveTime).AsyncWaitForCompletion();
        canClick = true;
    }
}
