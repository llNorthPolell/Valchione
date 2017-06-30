using UnityEngine;
using UnityEngine.UI;

public class DisplayHomeAction : SwitchScreenAction
{
    public GameObject homeScreen;
    public Button homeBtn;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Loading...";
        disableSubmitBtnOnSubmit = true;
        submitBtn = homeBtn;
    }

    protected override void transitionActions()
    {
        switchScreen(homeScreen);
    }
}
