using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DisplayCardMenuAction : SwitchScreenAction
{
    public GameObject cardMenuScreen;
    public Button cardMenuBtn;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Loading...";
        disableSubmitBtnOnSubmit = true;
        submitBtn = cardMenuBtn;
    }

    protected override void transitionActions()
    {
        switchScreen(cardMenuScreen);
    }
}
