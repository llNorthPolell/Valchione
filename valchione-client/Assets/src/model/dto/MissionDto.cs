using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionDto : IStorable {
    public int numOfPlayers;
    public int width;
    public int height;
    public string missionObjectives;

    public string altitude;
    public string tiles;

    public string gids;
    public string tileNames;
}
