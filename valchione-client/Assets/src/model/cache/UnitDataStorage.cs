using UnityEngine;
using System.Collections.Generic;

public class UnitDataStorage  {
    private static UnitDataStorage instance;
    private Dictionary<long, UnitData> unitDataDictionary = new Dictionary<long, UnitData>();

    private UnitDataStorage()
    {
    }

    public void addToStorage(UnitDto unitDto)
    {
        UnitData unitData = new UnitData(unitDto);
        unitDataDictionary.Add(unitDto.unitId, unitData);
    }
    

    public UnitData get(long id)
    {
        UnitData returnedUnitData = null;

        return  unitDataDictionary.TryGetValue(id, out returnedUnitData) ? new UnitData(returnedUnitData) : null;
    }

    public bool loaded()
    {
        return unitDataDictionary.Count > 0;
    }

    public static UnitDataStorage getInstance()
    {
        if (instance == null)
            instance = new UnitDataStorage();

        return instance;
    }

}
