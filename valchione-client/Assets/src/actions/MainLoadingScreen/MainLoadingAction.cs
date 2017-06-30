public class MainLoadingAction : OfflineLoadAction
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
        loadingScreenResources.updateProgress(MainScreenLoadConstants.INIT_TO_LOAD_UNIT_INFO, MainScreenLoadConstants.INIT_TO_LOAD_UNIT_INFO_TEXT);
        LoadUnitInfo loadUnitInfo = gameObject.AddComponent<LoadUnitInfo>();
    }
}
