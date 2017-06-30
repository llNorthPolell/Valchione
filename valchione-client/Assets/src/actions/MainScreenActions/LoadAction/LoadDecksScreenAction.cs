using UnityEngine;
using System.Collections.Generic;

public class LoadDecksScreenAction : OfflineLoadAction
{
    public int deckIndex;
    public GameObject deckContentScreenSpace;

    private List<PlayerCardDto> playerCards;
    private bool loadSuccessful;

    private GameObject baseCardObject;

    protected override void init()
    {
        baseCardObject = Resources.Load<GameObject>("ui/Card");
    }

    protected override void loadFromCache()
    {
        loadSuccessful = PlayerSession.getInstance().deckContents.TryGetValue(deckIndex, out playerCards);
    }

    protected override void otherActions()
    {
        LoadCardAction loadCardAction = baseCardObject.GetComponent<LoadCardAction>();


       // loadCardAction.setModals(errorModal, infoModal);
        GameObject body = GameObject.Find("Body");
        loadCardAction.body = body;
        loadCardAction.unitInfo = body.transform.FindChild("UnitInfo").gameObject;

        foreach (PlayerCardDto playerCard in playerCards)
        {
            loadCardAction.unitId = playerCard.cardId;

            GameObject newCard = Instantiate<GameObject>(baseCardObject);
            newCard.transform.SetParent(deckContentScreenSpace.transform);

        }


    }
}
