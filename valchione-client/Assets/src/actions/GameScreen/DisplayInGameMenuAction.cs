using UnityEngine;
using UnityEngine.UI;

public class DisplayInGameMenuAction : SwitchScreenAction
{
    public Button menuBtn;
    public GameObject menu;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        submitBtn = menuBtn;
    }

    protected override void transitionActions()
    {
        menu.SetActive(true);
    }
}
