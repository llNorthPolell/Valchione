using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitInGameCard : OfflineLoadAction
{
    public long unitId;
   // public GameObject body;
    //public GameObject unitInfo;

    private UnitData unitData;
    private Image typeImg;
    private Image portrait;

    protected override void init()
    {
        typeImg = transform.FindChild("Type").GetComponent<Image>();
        portrait = transform.FindChild("CardImgBg").FindChild("CardImage").GetComponent<Image>();
    }

    protected override void loadFromCache()
    {
        unitData = UnitDataStorage.getInstance().get(unitId);
    }

    protected override void otherActions()
    {
       /* DisplayUnitInfo displayUnitInfoAction = GetComponent<DisplayUnitInfo>();
        displayUnitInfoAction.setModals(errorModal, infoModal);
        displayUnitInfoAction.unitId = unitId;
        displayUnitInfoAction.body = body;
        displayUnitInfoAction.unitInfo = unitInfo;*/

        portrait.sprite = unitData.portrait;

        Image cardBorder = GetComponent<Image>();
        UnitTypeImgCache unitTypeImgCache = UnitTypeImgCache.getInstance();
        switch (unitData.unitType)
        {
            case "PRCG":
                cardBorder.color = CardColors.PIERCINGTYPECOLOR;
                break;
            case "SLSH":
                cardBorder.color = CardColors.SLASHTYPECOLOR;
                break;
            case "CRSH":
                cardBorder.color = CardColors.CRUSHTYPECOLOR;
                break;
            case "SHLD":
                cardBorder.color = CardColors.SHIELDTYPECOLOR;
                break;
            case "MGIC":
                cardBorder.color = CardColors.MAGICTYPECOLOR;

                break;
            default:
                break;
        }
        typeImg.sprite = unitTypeImgCache.get(unitData.unitType);
    }
}
