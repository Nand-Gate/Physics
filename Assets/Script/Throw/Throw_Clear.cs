using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Clear : MonoBehaviour
{
    public GameObject clearObj;
    void Start()
    {
        clearObj.SetActive(false);   
    }
    private void OnDestroy()
    {
        clearObj.SetActive(true);
    }
}
