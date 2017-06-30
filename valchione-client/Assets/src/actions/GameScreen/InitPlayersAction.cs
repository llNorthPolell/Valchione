using UnityEngine;

public class InitPlayersAction : OfflineLoadAction {
    private MissionDto missionDto;
    private GameController gameController;

    protected override void init()
    {
        gameController = GetComponent<DisplayGameScreenAction>().GameController;
    }

    protected override void loadFromCache()
    {
        missionDto = MissionSession.getInstance().missionDto;
    }

    protected override void otherActions()
    {
        GameObject playersContainer = new GameObject("Players");

        for (int i = 1; i <= missionDto.numOfPlayers; i++)
        {
            GameObject player = new GameObject("Player" + i);
            GameObject units = new GameObject("Units");
            player.transform.SetParent(playersContainer.transform);
            units.transform.SetParent(player.transform);
        }

        // TEST
        // Player 1 

        GameObject unit1 = gameController.spawnUnit(1, 1, new Vector3(0, 1, 0));
        gameController.spawnUnit(1, 2, new Vector3(1, 1, 0));
        gameController.spawnUnit(1, 2, new Vector3(2, 1, 0));
        gameController.spawnUnit(1, 2, new Vector3(1, 1, -1));
        gameController.spawnUnit(1, 1, new Vector3(0, 1, -1));


        unit1.GetComponent<UnitController>().unitData.conStats.currHp = 5;

        Effect stun = new Stun(unit1, 3);
        unit1.GetComponent<UnitStatusHandler>().addEffect(stun);

        // Player 2 
        gameController.spawnUnit(2, 1, new Vector3(15, 1, -15));
    }
}
