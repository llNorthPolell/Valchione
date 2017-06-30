using System.Collections.Generic;

public class UnpackCardsToDecksAction : OfflineLoadAction
{
    private List<PlayerCardDto> playerCards;

    protected override void init()
    {
        playerCards = new List<PlayerCardDto>();
    }

    protected override void loadFromCache()
    {
        PlayerSession playerSession = PlayerSession.getInstance();
        foreach (PlayerCardDto pc in playerSession.playerCards.Values)
            playerCards.Add(pc);
    }

    protected override void otherActions()
    {
        foreach (PlayerCardDto pc in playerCards)
            DeckCodeDecoder.unpackToDeck(pc);

        Dictionary<int, List<PlayerCardDto>> deckContents = PlayerSession.getInstance().deckContents;
    }
}
