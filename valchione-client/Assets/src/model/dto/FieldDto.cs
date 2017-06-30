using UnityEngine;
using System.Collections.Generic;

public class FieldDto  {

    private static FieldDto instance;
    private Dictionary<Vector2, GameObject> _playingField;


    public FieldDto()
    {

    }


    public Dictionary<Vector2, GameObject> playingField
    {
        get { return _playingField; }
        set { _playingField = value; }
    }
    
}
