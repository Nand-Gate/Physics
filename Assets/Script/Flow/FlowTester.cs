using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
public class FlowTester : MonoBehaviour
{
    public Box box;
    public float boxMass;
    public float waterMass;
    public int waterCount;
    public float shipMass;
    public float shipWidth;
    public float shipHeight;
    public Vector3 waterPivot;
    public Vector3 boxCreatePos;
    public float createRange;
    public float fallSpeed;
    public Vector2Int changeWaterRange;
    public Vector2 changeWaterCountTime;

    private List<GameObject> boxCount = new List<GameObject>();
    private Tweener tweener;
    private void Start()
    {
        SetFlown();
        ChangeWaterCount();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateBox();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DeleteBox();
        }
    }
    public async void CreateBox()
    {
        Box createBox = Instantiate(box, boxCreatePos + (Vector3.right * Random.value * createRange), Quaternion.identity);
        await UniTask.WaitUntil(() => createBox.setted);
        boxCount.Add(createBox.gameObject);
        SetFlown();
    }
    public void DeleteBox()
    {
        if (boxCount.Count == 0) return;
        Destroy(boxCount[boxCount.Count - 1]);
        boxCount.RemoveAt(boxCount.Count - 1);
        SetFlown();
    }
    public void SetFlown()
    {
        float mass = 0f;
        mass += shipMass;
        mass += boxCount.Count * boxMass;
        mass += waterMass * waterCount;
        float waterSize = mass / waterMass;
        float height = Mathf.Clamp(waterSize / shipWidth, 0, shipHeight + 1);
        tweener.Kill();
        tweener = transform.DOMove(waterPivot + Vector3.down * height, fallSpeed).SetEase(Ease.OutBack);
    }
    public async void ChangeWaterCount()
    {
        await UniTask.Delay((int)(Random.Range(changeWaterCountTime.x, changeWaterCountTime.y) * 1000f));
        int cash = waterCount;
        waterCount = Random.Range(changeWaterRange.x, changeWaterRange.y);
        Debug.Log(cash + "=>" + waterCount);
        SetFlown();
        ChangeWaterCount();
    }
}
