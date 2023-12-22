using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUI_LineCreater : MonoBehaviour
{
    public static StageUI_LineCreater instance;

    public RectTransform lineObj;
    public float lineWidth;

    private Transform mytrans;
    private void Awake()
    {
        instance = this;
        mytrans = transform;
    }
    public void CreateLine(Vector2 a,Vector2 b)
    {
        Vector2 pos = (a + b) / 2f;
        Quaternion v = Quaternion.LookRotation(Vector3.forward, a - b);
        RectTransform t = Instantiate(lineObj, pos, v, mytrans);
        t.localScale = new Vector3(lineWidth, (a - b).magnitude, 1);
    }
}
