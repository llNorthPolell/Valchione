using UnityEngine;
using System.Collections.Generic;

public class TileCache : MonoBehaviour {
    private static TileCache instance;
    private Dictionary<string, GameObject> tileCache;
    private Dictionary<int, string> tilesUsed;

    private TileCache()
    {
        tileCache = new Dictionary<string, GameObject>();
        tilesUsed = new Dictionary<int, string>();
        loadTerrain();
    }


    private void loadTerrain()
    {
        GameObject baseTile = Resources.Load<GameObject>("prefabs/Terrain/BaseTile");
        Material[] terrain = Resources.LoadAll<Material>("materials/Terrain");

        foreach (Material mat in terrain)
        {
            GameObject tile = Instantiate(baseTile);
            string tileName = mat.name.ToLower().Trim();

            tile.GetComponent<MeshRenderer>().material = mat;
            tileCache.Add(tileName, tile);

            Destroy(tile);
            tileCache[tileName].GetComponent<TileColorController>().enabled = true;
            tileCache[tileName].GetComponent<TileController>().enabled = true;
        }
    }
    
    public GameObject generateTile(string terrainName)
    {
        GameObject output = null;
        return tileCache.TryGetValue(terrainName, out output) ? Instantiate<GameObject>(output) : null;
    }

    public static TileCache getInstance()
    {
        if (instance == null)
            instance = new TileCache();

        return instance;
    }
}
