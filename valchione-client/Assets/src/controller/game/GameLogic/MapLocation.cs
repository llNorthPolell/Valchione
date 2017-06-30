using UnityEngine;
using System.Collections;

public class MapLocation  {

    public GameObject topTile { get; set; }
    public GameObject unit { get; set; }
    public GameObject structure { get; set; }


    public MapLocation(GameObject topTile)
    {
        this.topTile = topTile;
    }



}
