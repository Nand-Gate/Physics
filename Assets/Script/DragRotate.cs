using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class DragRotate : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public Image roteImage;
    public TextMeshProUGUI text;

    private float startAngle;
    private float beforeAngle;
    [SerializeField] private float nowAngle;
    private Camera mainCamera;
    private Transform mytrans;
    void Start()
    {
        mytrans = transform;
        mainCamera = Camera.main;
        roteImage.transform.position = mainCamera.WorldToScreenPoint(mytrans.position);
        roteImage.fillAmount = (mytrans.rotation.eulerAngles.z + 90f) % 360f / 360f;
        text.text = ((mytrans.rotation.eulerAngles.z + 90f) % 360f).ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(mytrans.up * 2);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 vec = GetMousePos(eventData.position) - mytrans.position;
        startAngle = vec.Angle();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 vec = GetMousePos(eventData.position) - mytrans.position;
        float dragAngle = vec.Angle() - startAngle;
        nowAngle = dragAngle + beforeAngle;
        mytrans.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(nowAngle));
        roteImage.fillAmount = (mytrans.rotation.eulerAngles.z + 90f) % 360f / 360f;
        text.text = ((mytrans.rotation.eulerAngles.z + 90f) % 360f).ToString();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beforeAngle = nowAngle;
    }
    public Vector3 GetMousePos(Vector2 eventD)
    {
        Vector3 v = mainCamera.ScreenToWorldPoint(eventD);
        v.z = mytrans.position.z;
        return v;
    }
}
