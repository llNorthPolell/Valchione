using UnityEngine;
using System.Collections;


/* Sets up a unit game object */
public class UnitLoader : MonoBehaviour {
    public long unitId { get; set; }
    public int playerNum { get; set; }

    public void setup(Vector3 spawnLocation)
    {
        GameData data = Camera.main.GetComponent<GameData>();
        if (unitId == 0)
            return;

        GameObject newModel = UnitModelCache.getInstance().generateModel(unitId);

        name = unitId.ToString();
        newModel.transform.SetParent(transform, false);

        gameObject.AddComponent<UnitColorController>();
        // UnitDataController unitDataController = gameObject.AddComponent<UnitDataController>();
        //unitDataController.unitId = unitId;

        gameObject.AddComponent<UnitStatusHandler>().init();


        UnitController unitController = gameObject.AddComponent<UnitController>();
        unitController.unitId = unitId;
        unitController.ownerNum = playerNum;

        transform.position = spawnLocation;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));


        unitController.init();

        data.map[VectorUtil.convertVect3To2(spawnLocation)].unit = gameObject;
        
    }
    
}
