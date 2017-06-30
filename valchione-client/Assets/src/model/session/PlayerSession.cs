using System.Collections.Generic;
using UnityEngine;

public class PlayerSession {
    private static PlayerSession instance;

    private PlayerDto _playerDto;
    
    public Dictionary<long, PlayerCardDto> playerCards
    {
        get;
        private set;
    }

    public Dictionary<int, DeckDto> deckMeta
    {
        get;
        private set;
    }

    public Dictionary<int, List<PlayerCardDto>> deckContents { get; set; }

    private PlayerSession()
    {
        playerCards = new Dictionary<long, PlayerCardDto>();
        deckMeta = new Dictionary<int, DeckDto>();
        deckContents = new Dictionary<int, List<PlayerCardDto>>();
    }

    public PlayerDto playerDto
    {
        get { return _playerDto; }
        set {
            _playerDto = (_playerDto==null && value!=null)? value : null;
        }
    }
  
    public void addPlayerCard(PlayerCardDto playerCardDto)
    {
        playerCards.Add(playerCardDto.profileCardId, playerCardDto);
    }

    public void addDeck(DeckDto deckDto)
    {
        deckMeta.Add(deckDto.deckIndex, deckDto);
        deckContents.Add(deckDto.deckIndex,new List<PlayerCardDto>());
    }

    public PlayerCardDto getPlayerCard(long id)
    {
        PlayerCardDto output = null;

        return (playerCards.TryGetValue(id, out output))? output : null;
    }

    public DeckDto getDeckMeta(int index)
    {
        DeckDto output = null;

        return (deckMeta.TryGetValue(index, out output)) ? output : null;

    }

    public void addToDeck(int index, PlayerCardDto playerCard)
    {
        List<PlayerCardDto> deckContent = null;

        if (deckContents.TryGetValue(index, out deckContent))
            deckContent.Add(playerCard);
    }

    public void removeFromDeck(int index, PlayerCardDto playerCard)
    {
        List<PlayerCardDto> deckContent = null;

        if (deckContents.TryGetValue(index, out deckContent))
            deckContent.Remove(playerCard);
    }

    public static PlayerSession getInstance()
    {
        if (instance == null) instance = new PlayerSession();
        return instance;
    }


    public void displayDeckSizes()
    {
        foreach(KeyValuePair<int, List<PlayerCardDto>> dc in deckContents)
            Debug.Log(getDeckMeta(dc.Key).deckName+":"+dc.Value.Count);
    }
}
