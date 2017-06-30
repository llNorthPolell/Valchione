using UnityEngine;
using System.Collections.Generic;
using System;

public class LoadPlayerCardsScreenAction : OfflineLoadAction
{
    private Dictionary<long, PlayerCardDto> playerCards;

    private GameObject baseCardObject;
    private bool loaded;

    protected override void init()
    {
        loaded = false;
        baseCardObject = Resources.Load<GameObject>("ui/Card");
    }

    protected override void loadFromCache()
    {
        playerCards = PlayerSession.getInstance().playerCards;     
    }

    protected override void otherActions()
    {
        if (!loaded)
        {
            GameObject playerCardsScreen = GameObject.Find("PlayerCardsScreen");

            LoadCardAction loadCardAction = baseCardObject.GetComponent<LoadCardAction>();

            GameObject body = GameObject.Find("Body");
            loadCardAction.body = body;
            loadCardAction.unitInfo = body.transform.FindChild("UnitInfo").gameObject;
            
            foreach(PlayerCardDto playerCard in playerCards.Values)
            {
                loadCardAction.unitId = playerCard.cardId;

                GameObject newCard = Instantiate<GameObject>(baseCardObject);
                newCard.transform.SetParent(playerCardsScreen.transform);

            }
        }
    }
}
