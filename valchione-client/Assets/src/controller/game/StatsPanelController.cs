using UnityEngine;
using UnityEngine.UI;

public class StatsPanelController : MonoBehaviour {
    private const string HPLABEL = "HP ";
    private const string ATKLABEL = "ATK ";
    private const string DEFLABEL = "DEF ";
    private const string SPLABEL = "SP ";
    private const string MVTLABEL = "Movement ";
    
    public Text unitName;
    public Text hp;
    public Text atk;
    public Text def;
    public Text sp;
    public Text mvt;
    public GameObject portrait;

    private UnitData unitData;
    private GameData data;

    void Start()
    {
        data = Camera.main.GetComponent<GameData>();
        
    }

    public void setStats()
    {
        unitData = data.selectedUnit.GetComponent<UnitController>().unitData;
        unitName.text = unitData.unitName;
        hp.text = HPLABEL + unitData.conStats.currHp + "/" + unitData.conStats.maxHp;
        atk.text = ATKLABEL + unitData.advStats.pAtk;
        def.text = DEFLABEL + unitData.advStats.pDef;
        sp.text = SPLABEL + unitData.conStats.maxSp;
        mvt.text = MVTLABEL + unitData.baseStats.spd;

        portrait.GetComponent<Image>().sprite = unitData.portrait;

    }
}
