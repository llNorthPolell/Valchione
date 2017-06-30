public class GameLoadingAction : OfflineLoadAction
{
    protected override void init()
    {
    }

    protected override void loadFromCache()
    {
    }

    protected override void otherActions()
    {
        LoadingScreenResources loadingScreenResources = GetComponent<LoadingScreenResources>();
        loadingScreenResources.updateProgress(GameLoadingScreenConstants.INIT_TO_LOAD_MISSION_INFO, GameLoadingScreenConstants.INIT_TO_LOAD_MISSION_INFO_TEXT);
        LoadMissionInfoAction loadGameAction = gameObject.AddComponent<LoadMissionInfoAction>();  
    }
}
