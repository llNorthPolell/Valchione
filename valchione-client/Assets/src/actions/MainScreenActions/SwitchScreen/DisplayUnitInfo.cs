using UnityEngine;
using UnityEngine.UI;

public class DisplayUnitInfo : SwitchScreenAction
{
    public GameObject unitInfo;
    public long unitId;
    

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Loading...";
        disableSubmitBtnOnSubmit = false;
        submitBtn = this.GetComponent<Button>();
    }

    protected override void transitionActions()
    {
        unitInfo.GetComponent<ViewUnitInfo>().unitId = unitId;
        switchScreen(unitInfo);
        unitInfo.GetComponent<ViewUnitInfo>().reload();
    }
}
