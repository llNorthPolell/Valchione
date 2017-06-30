using UnityEngine;
using UnityEngine.UI;

public class DisplayGameScreenAction : OfflineLoadAction {
    public Text missionName;

    public GameController GameController { get; private set; }
    private GameData gameData;
    private MissionDto missionDto;

    protected override void init()
    {
        GameController = new GameControllerImpl();
        gameData = Camera.main.GetComponent<GameData>();
    }

    protected override void loadFromCache()
    {
        missionDto = MissionSession.getInstance().missionDto;
    }

    protected override void otherActions()
    {
        missionName.text += MissionSession.getInstance().missionId.ToString();

        gameData.numOfPlayers = missionDto.numOfPlayers;

        GameController.initGameDispatchers();
        GameController.generateMap(missionDto);

        gameObject.AddComponent<InitPlayersAction>();
        

    }
}
