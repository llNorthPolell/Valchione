using UnityEngine;
using System.Collections.Generic;

public class FieldControllerImpl : FieldController{
    private FieldGenerator fieldGenerator;

    private GameData data;
    private List<GameObject> walkables;
    private List<GameObject> unwalkables;
    private List<Vector2> path;

    public FieldControllerImpl()
    {
        data = Camera.main.GetComponent<GameData>();
        walkables = new List<GameObject>();
        unwalkables = new List<GameObject>();
        path = new List<Vector2>();
    }

    public void generateMap(MissionDto missionDto)
    {
        fieldGenerator = new FieldGeneratorImpl(missionDto);
        fieldGenerator.generateMap();
    }

    public static void loadMap(FieldDto field)
    {
        GameData gameData = Camera.main.GetComponent<GameData>();
        gameData.map = new Dictionary<Vector2, MapLocation>();
        foreach (KeyValuePair<Vector2, GameObject> pair in field.playingField)
            gameData.map[pair.Key] = new MapLocation(pair.Value);
        
    }

    public void highlightWalkables()
    {
        GameObject unit = data.selectedUnit;

        if (unit != null) {
            UnitController uc = unit.GetComponent<UnitController>();
            Vector2 unitLocation = uc.currentPosition;

            if (walkables.Count == 0)
                loadWalkables(unitLocation, uc.movement);

            foreach (GameObject tile in walkables)
                tile.GetComponent<TileColorController>().highlight();

            foreach (GameObject tile in unwalkables)
                tile.GetComponent<TileColorController>().invalidate();
        }
        
    }

    public void forgetWalkables()
    {
        foreach (GameObject tile in walkables)
            tile.GetComponent<TileColorController>().reset();
        foreach (GameObject tile in unwalkables)
            tile.GetComponent<TileColorController>().reset();

        walkables = new List<GameObject>();
        unwalkables = new List<GameObject>();
    }

    public void loadWalkables(Vector2 location, int movement)
    {
        if (!data.map.ContainsKey(location))
            return;

        MapLocation mapLocation = data.map[location];
        GameObject currentTile = mapLocation.topTile;
        Vector3 unitLocation = data.selectedUnit.transform.position;

        if (!walkables.Contains(currentTile))
            if (locationPassible(currentTile, unitLocation))
            {
                unwalkables.Add(currentTile);
                return;
            }
            else if (locationOccupied(mapLocation))
                unwalkables.Add(currentTile);
            
            else
                walkables.Add(currentTile);
        

        if (movement== 0)
            return;

        loadWalkables(location + Vector2.left, movement - 1);   // west
        loadWalkables(location + Vector2.right, movement - 1);  // east
        loadWalkables(location + Vector2.up, movement - 1);     // north
        loadWalkables(location + Vector2.down, movement - 1);   // south
    }

    private bool locationOccupied(MapLocation mapLocation)
    {
        return mapLocation.unit != null && mapLocation.unit != data.selectedUnit;
    }

    private bool locationPassible(GameObject currentTile, Vector3 currentLocation)
    {
        return currentTile.transform.position.y > currentLocation.y + 2
                || currentTile.transform.position.y < currentLocation.y - 2;
    }

    public void plotPath(List<Vector2> path)
    {
        forgetPathPlot();
        this.path = path;
        UnitController selectedUnitController = data.selectedUnit.GetComponent<UnitController>();

        foreach (Vector2 node in path)
            data.map[node].topTile.GetComponent<TileColorController>().markWalked();
        
    }

    public void forgetPathPlot()
    {
        resetPath();
        highlightWalkables();
    }

    public void resetPath()
    {
        foreach (Vector2 node in path)
            data.map[node].topTile.GetComponent<TileColorController>().reset();

        path.Clear();
    }
}
