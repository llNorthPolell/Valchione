using System;
using UnityEngine;

public class VectorUtil  {
    

    public static Vector2 convertVect3To2(Vector3 input)
    {
        return new Vector2(input.x, input.z);
    }

    internal static Vector2 gridLock(Vector2 input)
    {
        return new Vector2(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y));
    }
}
