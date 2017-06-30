using UnityEngine;
using UnityEngine.UI;

public class MainScreenAction : OfflineLoadAction {
    public Text playerNameText;
    public Text playerLevelText;
    public Text playerExpText;
    public Text coinsText;
    public Text gemsText;
    public Text honorPointsText;
    public GameObject leaderImage;

    protected override void init()
    {       
    }

    protected override void otherActions()
    {
    }

    protected override void loadFromCache()
    {
        PlayerSession ps = PlayerSession.getInstance();
        PlayerDto playerDto = ps.playerDto;

        playerNameText.text += playerDto.username;
        playerLevelText.text += playerDto.playerLevel.ToString();
        playerExpText.text += playerDto.playerExp.ToString();
        coinsText.text += playerDto.coins.ToString();
        gemsText.text += playerDto.gems.ToString();
        honorPointsText.text += playerDto.honorPoints.ToString();
        long leaderId = ps.getDeckMeta(1).leaderId;

        if (leaderId != 0)
        {
            long leaderUnitId = ps.getPlayerCard(leaderId).cardId;
            leaderImage.GetComponent<Image>().sprite = UnitDataStorage.getInstance().get(leaderUnitId).fullSprite;
        }
    }
}
