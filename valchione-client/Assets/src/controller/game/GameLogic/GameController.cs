using UnityEngine;

public interface GameController {
    void initGameDispatchers();
    void generateMap(MissionDto missionDto);
    int nextTurn();
    TurnPhase nextPhase();
    void selectUnit(GameObject unit);
    void deselectUnit();
    void plotMove(GameObject unit, GameObject tile);
    void cancelMove();
    void confirmMove();
    GameObject spawnUnit(int playerNum, long unitId, Vector3 location);
    GameObject spawnStructures(int playerNum, long structureId, Vector3 location);
}
