using UnityEngine;
using UnityEngine.UI;

public class HideInGameMenuAction : SwitchScreenAction
{
    
    public GameObject menu;

    private Button continueBtn;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        continueBtn = GetComponent<Button>();
        submitBtn = continueBtn;
    }

    protected override void transitionActions()
    {
        menu.SetActive(false);
    }
}
