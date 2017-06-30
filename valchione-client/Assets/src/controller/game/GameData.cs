using UnityEngine;
using System.Collections.Generic;

internal class GameData : MonoBehaviour {
    internal int playerNum { get; set; }
    internal int numOfPlayers { get; set; }
    internal TurnPhase phase { get; set; }
    internal int turn { get; set; }
    internal GameObject selectedUnit { get; set; }
    internal Dictionary<Vector2, MapLocation> map;
    
}
