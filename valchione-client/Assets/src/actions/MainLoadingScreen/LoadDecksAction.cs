using UnityEngine;
using System;

public class LoadDecksAction : OnlineLoadAction {

    private String username;

    protected override void init()
    {
        PlayerDto playerDto = PlayerSession.getInstance().playerDto;
        if (playerDto != null)
            username = playerDto.username;
    }

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

    protected override string onError(int errorCode)
    {
        switch (errorCode)
        {
            case 404:
                return "Player Decks"+ErrorMessages.NOTFOUND;
            default:
                return ErrorMessages.UNKNOWN;
        }
    }

    protected override void onSuccess(string successWWWText)
    {
        DeckDto[] deckDtoArr = JsonInputProcessor.createManyFromJson<DeckDto>(successWWWText);
        PlayerSession playerSession = PlayerSession.getInstance();

        foreach (DeckDto deckDto in deckDtoArr)
            playerSession.addDeck(deckDto);


        UnpackCardsToDecksAction unpackCardsToDecksAction = gameObject.AddComponent<UnpackCardsToDecksAction>();

        LoadingScreenResources loadingScreenResources = GetComponent<LoadingScreenResources>();
        loadingScreenResources.updateProgress(MainScreenLoadConstants.PROCEED_TO_MAIN_SCREEN, MainScreenLoadConstants.PROCEED_TO_MAIN_SCREEN_TEXT);


    }

    protected override void setLoadInformation()
    {
        url = BASEURL + "/loadDecks";
    }
}
