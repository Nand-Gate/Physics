using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExpand
{
    public static float Angle(this Vector2 value)
    {
        return Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
    }
    public static float Angle(this Vector3 value)
    {
        return Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
    }
}
