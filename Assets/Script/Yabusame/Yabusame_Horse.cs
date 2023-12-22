using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yabusame_Horse : MonoBehaviour
{
    public Morter[] wheel;
    public Mover mover;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0;i < wheel.Length; i++)
            {
                wheel[i].SetActivate(true);
            }
            mover.SetActivate(true);
        }
    }
}
