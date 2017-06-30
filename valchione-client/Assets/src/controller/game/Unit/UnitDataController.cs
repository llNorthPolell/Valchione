using UnityEngine;

public class UnitDataController : MonoBehaviour {
    private long _unitId;
    public UnitData unitData { get; private set; }

    public long unitId {
        get { return _unitId; }
        set {
            _unitId = value;
            unitData = UnitDataStorage.getInstance().get(_unitId);
        }
    }
}
