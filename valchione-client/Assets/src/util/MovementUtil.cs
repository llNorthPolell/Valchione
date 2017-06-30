using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MovementUtil {
    private static List<Vector2> closedSet;
    private static List<Vector2> openSet;
    private static Dictionary<Vector2, Vector2> cameFrom;
    private static Dictionary<Vector2, int> moveRating;
    private static Dictionary<Vector2, int> cost;
    private static List<Vector2> adjNodes;
    private static GameData data;
    
    public static List<Vector2> pathfind(Vector2 from, Vector2 to)
    {
        closedSet = new List<Vector2>();
        openSet = new List<Vector2>();
        cameFrom = new Dictionary<Vector2,Vector2>();
        moveRating = new Dictionary<Vector2, int>();
        cost = new Dictionary<Vector2, int>();

        openSet.Add(from);
        cost[from] = 0;
        moveRating[from] = getMoveRating(from, to);

        while (openSet.Count>0)
        {
            Vector2 current = openSet.First();
            if (current.Equals(to))
                return reconstructPath(cameFrom, current);
            

            openSet.Remove(current);
            closedSet.Add(current);
            
            getOpenAdjacentNodes(current);

            foreach (Vector2 adjNode in adjNodes)
            {
                if (closedSet.Contains(adjNode) || openSet.Contains(adjNode))
                    continue;

                openSet.Add(adjNode);
                cameFrom[adjNode] = current;
                cost[adjNode] = getMoveRating(from, adjNode);
                moveRating[adjNode] = getMoveRating(adjNode, to);
            }
        }

        Debug.Log("Node Inaccessible...");
        return new List<Vector2>();
    }
    
    private static int getMoveRating(Vector2 node, Vector2 to)
    {
        return Mathf.RoundToInt(Vector2.Distance(node, to));
    }

    private static void getOpenAdjacentNodes(Vector2 node)
    {
        data = Camera.main.GetComponent<GameData>();
        adjNodes = new List<Vector2>();

        Vector2 westNode = node + Vector2.left;
        Vector2 eastNode = node + Vector2.right;
        Vector2 northNode = node + Vector2.up;
        Vector2 southNode = node + Vector2.down;

        MapLocation currentLocation = null;

        if (data.map.TryGetValue(node, out currentLocation))
        {
            float y = currentLocation.topTile.transform.position.y;
            addReachableAdjNodeIfNew(y, northNode);
            addReachableAdjNodeIfNew(y, southNode);
            addReachableAdjNodeIfNew(y, eastNode);
            addReachableAdjNodeIfNew(y, westNode);
        }
    }

    private static void addReachableAdjNodeIfNew(float currentAltitude, Vector2 adjNode)
    {
        if (data.map.ContainsKey(adjNode)
            && !closedSet.Contains(adjNode)
            && !openSet.Contains(adjNode))
        {
            float adjNodeY = data.map[adjNode].topTile.transform.position.y;
            if (adjNodeY <= currentAltitude + 1
                && adjNodeY >= currentAltitude - 1)
                adjNodes.Add(adjNode);
        }
    }


    private static List<Vector2> reconstructPath(Dictionary<Vector2, Vector2> cameFrom, Vector2 destination)
    {
        List<Vector2> path = new List<Vector2>();
        Vector2 current = destination;
        path.Add(current);

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Add(current);
        }
        path.Reverse();
        return path;
    }
}
