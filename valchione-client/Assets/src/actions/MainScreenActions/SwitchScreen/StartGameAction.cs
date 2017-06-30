using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameAction : OfflineSubmitAction
{

    public Button startGameBtn;
    public int missionId;

    
    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Starting Game... ";
        disableSubmitBtnOnSubmit = false;
        submitBtn = startGameBtn;
    }

    protected override void transitionActions()
    {
        MissionSession.getInstance().missionId = missionId;
        SceneManager.LoadScene("gameLoadingScreen");
    }
}
