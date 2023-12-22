using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int l = 0; l < 10; l++)
                {
                    for (int t = 0; t < 10; t++)
                    {
                        Debug.Log(i.ToString() + j.ToString() + l.ToString() + t.ToString());
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
