using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2D2RDZ
{
    public static Quaternion Rotate2D(Vector3 from, Vector3 to, float offset = 0)
    {

        Quaternion rotation = R2D2RDZ.Rotate2D(new Vector3(to.x - from.x, to.y - from.y), offset);
        return rotation;
    }

    public static Quaternion Rotate2D(Vector3 direction, float offset = 0)
    {
        if (direction.x < 0) offset = -offset;
        Quaternion rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(direction.y / direction.x) * 57.295f + offset);
        return rotation;
    }

    public static float Rotate2DEuler(Vector3 from, Vector3 to, float offset = 0)
    {
        float angle = Rotate2DEuler(new Vector3(to.x - from.x, to.y - from.y), offset);
        return angle;
    }

    public static float Rotate2DEuler(Vector3 direction, float offset = 0)
    {
        float angle = Mathf.Atan(direction.y / direction.x) * 57.295f + offset;
        return angle;
    }
}
