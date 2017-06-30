using UnityEngine;

public class LoadUnitInfo : OnlineLoadAction {
    private string unitId = "0";
    

    protected override void addFields(WWWForm form)
    {
        form.AddField(FormConstants.UNITID, unitId);
    }

    protected override bool fieldsValid()
    {
        return unitId != null && unitId.Length > 0 && !UnitDataStorage.getInstance().loaded();
    }

    protected override void handleInvalidFields()
    {
    }

    protected override void init()
    {
    }

    protected override string onError(int errorCode)
    {
        switch (errorCode)
        {
            case 404:
                return "Unit Info "+ErrorMessages.NOTFOUND;

            default:
                return ErrorMessages.UNKNOWN;

        }
    }

    protected override void onSuccess(string successWWWText)
    {
        UnitDto[] unitDtoList = JsonInputProcessor.createManyFromJson<UnitDto>(successWWWText);
        UnitDataStorage storage = UnitDataStorage.getInstance();

        foreach (UnitDto unitDto in unitDtoList)
            storage.addToStorage(unitDto);

        
        LoadingScreenResources loadingScreenResources = GetComponent<LoadingScreenResources>();
        loadingScreenResources.updateProgress(MainScreenLoadConstants.LOAD_UNIT_INFO_TO_LOAD_PLAYER_CARDS, MainScreenLoadConstants.LOAD_UNIT_INFO_TO_LOAD_PLAYER_CARDS_TEXT);

        LoadPlayerCardsAction loadPlayerCardsAction = gameObject.AddComponent<LoadPlayerCardsAction>();
    }
    protected override void setLoadInformation()
    {
        url = BASEURL + "/loadUnitInfo";
    }
    
}
