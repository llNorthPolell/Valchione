using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ViewUnitInfo : OfflineLoadAction
{
    public long unitId;
    public Text unitNameText;
    public GameObject unitTypeImg;
    public Text hpText;
    public Text strText;
    public Text sprText;
    public Text agiText;
    public Text spdText;
    public GameObject unitFullImage;

    private Sprite unitFullSprite;
    private Sprite unitTypeSprite;

    private UnitData unitData;

    protected override void init()
    {
        unitData = UnitDataStorage.getInstance().get(unitId);
    }

    protected override void loadFromCache()
    {
        if (unitData != null)
        {
            unitNameText.text = unitData.unitName;
            hpText.text = "HP: "+unitData.baseStats.hp.ToString();
            strText.text = "STR: " + unitData.baseStats.str.ToString();
            sprText.text = "SPR: " + unitData.baseStats.spr.ToString();
            agiText.text = "AGI: " + unitData.baseStats.agi.ToString();
            spdText.text = "SPD: " + unitData.baseStats.spd.ToString();
            unitFullSprite = Instantiate<Sprite>(unitData.fullSprite);
            unitFullImage.GetComponent<Image>().sprite = unitFullSprite;
            unitTypeSprite = Instantiate<Sprite>(UnitTypeImgCache.getInstance().get(unitData.unitType));
            unitTypeImg.GetComponent<Image>().sprite = unitTypeSprite;
        }else
        {
            Debug.Log("Unit Info not loaded yet...");
        }

    }

    protected override void otherActions()
    {
    }
}
