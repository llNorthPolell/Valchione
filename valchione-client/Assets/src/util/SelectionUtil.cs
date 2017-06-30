using UnityEngine;

public class SelectionUtil  {
    public static bool isUnit(GameObject obj)
    {
        return obj.GetComponent<UnitController>() != null;
    }

    public static bool isTile(GameObject obj)
    {
        return obj.GetComponent<TileController>() != null;
    }
}
