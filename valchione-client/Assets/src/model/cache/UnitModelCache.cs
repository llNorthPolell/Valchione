using UnityEngine;
using System.Collections.Generic;

public class UnitModelCache {
    private static UnitModelCache instance;
    private Dictionary<long, GameObject> modelDictionary;

	private UnitModelCache()
    {
        modelDictionary = new Dictionary<long, GameObject>();
        loadModels();
    }


    public static UnitModelCache getInstance()
    {
        if (instance == null) instance = new UnitModelCache();
        return instance;
    }

    private void loadModels()
    {
        GameObject[] models = Resources.LoadAll<GameObject>("prefabs/Characters/Models");

        foreach (GameObject model in models)
        {
            long unitId = 0;

            if (!long.TryParse(model.name, out unitId))
                continue;

            modelDictionary.Add(unitId, model);
        }
    }

    public GameObject generateModel(long unitId)
    {
        return (GameObject) GameObject.Instantiate(modelDictionary[unitId], Vector3.zero, Quaternion.Euler(new Vector3(0,180,0)));
    }
}
