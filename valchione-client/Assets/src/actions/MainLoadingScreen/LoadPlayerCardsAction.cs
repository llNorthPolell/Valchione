using UnityEngine;

public class LoadPlayerCardsAction : OnlineLoadAction
{
    private string username;
    

    protected override void addFields(WWWForm form)
    {
        form.AddField(FormConstants.USERNAME, username);
    }

    protected override bool fieldsValid()
    {
        return username != null && username.Length > 0;
    }

    protected override void handleInvalidFields()
    {
        errorModalController.DisplayMessage(ErrorMessages.SESSIONLOST, Scenes.LOGIN);
    }

    protected override void init()
    {
        PlayerDto playerDto = PlayerSession.getInstance().playerDto;
        if (playerDto!=null)
            username = playerDto.username;

    }

    protected override string onError(int errorCode)
    {
        switch (errorCode)
        {
            case 404:
                return "Player Cards" + ErrorMessages.NOTFOUND;

            default:
                return ErrorMessages.UNKNOWN;

        }
    }

    protected override void onSuccess(string successWWWText)
    {
        PlayerCardDto[] playerCardDtoArr = JsonInputProcessor.createManyFromJson<PlayerCardDto>(successWWWText);

        PlayerSession playerSession = PlayerSession.getInstance();
        foreach(PlayerCardDto pc in playerCardDtoArr)
            playerSession.addPlayerCard(pc);

        LoadingScreenResources loadingScreenResources = GetComponent<LoadingScreenResources>();
        loadingScreenResources.updateProgress(MainScreenLoadConstants.LOAD_PLAYER_CARDS_TO_LOAD_DECKS, MainScreenLoadConstants.LOAD_PLAYER_CARDS_TEXT_TO_LOAD_DECKS_TEXT);

        LoadDecksAction loadDecksAction = gameObject.AddComponent<LoadDecksAction>();
    }

    protected override void setLoadInformation()
    {
        url = BASEURL + "/loadPlayerCards";
    }
}
