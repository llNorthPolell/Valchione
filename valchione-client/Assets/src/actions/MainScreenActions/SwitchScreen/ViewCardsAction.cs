using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class ViewCardsAction : SwitchScreenAction
{
    public GameObject playerCardsScreen;
    public Button viewCardsBtn;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Loading...";
        disableSubmitBtnOnSubmit = true;
        submitBtn = viewCardsBtn;
    }

    protected override void transitionActions()
    {
        switchScreen(playerCardsScreen);
       // playerCardsScreen.GetComponent<PlayerCardsScreenData>().cameFrom = "VIEW";
    }

   
}
