using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector2 baseScale;
    public Vector2Int widthRange;
    public Vector2Int heightRange;
    public Vector2Int weightRange;
    public float waterPer;
    public float sinkSpeed;

    private Vector3 refVec;
    private int weight;
    private Vector2Int scale;
    void Start()
    {
        scale = new Vector2Int(Random.Range(widthRange.x, widthRange.y + 1), Random.Range(heightRange.x, heightRange.y + 1));
        Vector2 scalePer = new Vector2((float)scale.x / baseScale.x, (float)scale.y / baseScale.y);
        transform.localScale = scalePer;
        weight = Random.Range(weightRange.x,Mathf.Min(weightRange.y + 1,scale.x * scale.y * 1000));
    }
    void Update()
    {
        Sink();
    }
    public float GetAllWeight()
    {
        float water = (float)(scale.x * scale.y * 1000) * waterPer;
        return water + weight;
    }
    public void Sink()
    {
        float w = GetAllWeight();
        float h = w / 1000f / (scale.x);
        if (h <= 0) h = 0;
        if(h > scale.y)
        {
            EverySink();
        }
        else
        {
            Vector3 d = Vector3.SmoothDamp(transform.position, Vector3.down * h,ref refVec,0.75f);
            transform.position = d;
        }
    }
    public void EverySink()
    {
        transform.Translate(Vector3.down * Time.deltaTime * sinkSpeed);
    }
}
