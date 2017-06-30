using UnityEngine;

public class LoadMissionInfoAction : OnlineLoadAction
{
    private int missionId;
    private MissionSession missionSession;

    protected override void addFields(WWWForm form)
    {
        form.AddField(FormConstants.MISSIONID, missionId);
    }

    protected override bool fieldsValid()
    {
        return missionId > 0;
    }

    protected override void handleInvalidFields()
    {
        errorModalController.DisplayMessage(ErrorMessages.NOMISSIONINFO, Scenes.MAIN);
    }

    protected override void init()
    {
        missionSession = MissionSession.getInstance();
        missionSession.missionId = 02;
        int missionId = MissionSession.getInstance().missionId;
    }

    protected override string onError(int errorCode)
    {
        switch (errorCode)
        {
            case 404:
                return "Mission " + ErrorMessages.NOTFOUND;

            default:
                return ErrorMessages.UNKNOWN;
        }
    }

    protected override void onSuccess(string successWWWText)
    {
        MissionDto missionDto = JsonInputProcessor.createFromJson<MissionDto>(successWWWText);
        MissionSession.getInstance().missionDto = missionDto;

        LoadingScreenResources loadingScreenResources = GetComponent<LoadingScreenResources>();
        loadingScreenResources.updateProgress(GameLoadingScreenConstants.PROCEED_TO_GAME, GameLoadingScreenConstants.PROCEED_TO_GAME_TEXT);
    }

    protected override void setLoadInformation()
    {
        url = BASEURL + "/loadMission";
        missionId = MissionSession.getInstance().missionId;
    }
}
