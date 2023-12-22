using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class StageNode : MonoBehaviour,IPointerClickHandler
{
    public static StageNode nowSelectNode = null;
    public float moveTime = 0.5f;
    public string sceneName;
    public Transform otherNode;

    private Vector3 pivot;
    private Vector3 vec;
    private Transform baseTrans;
    private Transform cameraTrans;
    private Transform mytrans = null;
    void Start()
    {
        pivot = new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0);
        mytrans = transform;
        baseTrans = mytrans.parent;
        cameraTrans = Camera.main.transform;
        vec = pivot - mytrans.localPosition;
        if(otherNode != null)StageUI_LineCreater.instance.CreateLine(mytrans.position, otherNode.position);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(nowSelectNode != this)
        {
            nowSelectNode = this;
            baseTrans.DOMove(vec, moveTime);
        }
        else
        {
            SceneLoader.manager.GoScene(sceneName);
        }
    }
}
