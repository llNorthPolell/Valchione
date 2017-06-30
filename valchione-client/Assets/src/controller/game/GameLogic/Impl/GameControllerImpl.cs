using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Main facade for game functionality.
/// </summary>
public class GameControllerImpl : GameController{
    private GameData data;
    private BottomPanelController bottomPanelController;
    private FieldController fieldController;
    private TurnController turnController;
    private IDictionary<int, CommandDispatcher> cmdDispatchers;

    public GameControllerImpl()
    {
        fieldController = new FieldControllerImpl();
        turnController = new TurnControllerImpl();

        data = Camera.main.GetComponent<GameData>();
        data.playerNum = 1; //TEST
        bottomPanelController = GameObject.Find("BottomPanel").GetComponent<BottomPanelController>();
    }

    public void initGameDispatchers()
    {
        cmdDispatchers = new Dictionary<int, CommandDispatcher>();
        for(int i=1; i<= data.numOfPlayers; i++)
            cmdDispatchers.Add(i, new CommandDispatcherImpl(i));
    }

    public void generateMap(MissionDto missionDto)
    {
        fieldController.generateMap(missionDto);
    }

    public int nextTurn()
    {
        applyEffects(ActivationRule.TURN_END, data.turn);
        turnController.nextTurn();
        bottomPanelController.changePanels();
        resetUnitMoves(data.turn);
        applyEffects(ActivationRule.TURN_START, data.turn);
     
        return turnController.getCurrTurn();
    }

    private void resetUnitMoves(int playerNum)
    {
        GameObject player = GameObject.Find("Player" + playerNum);
        GameObject units = player.transform.FindChild("Units").gameObject;
        UnitController[] ucs = units.GetComponentsInChildren<UnitController>();

        foreach (UnitController uc in ucs)
            uc.refreshMove();

        
    }

    private void applyEffects(ActivationRule activationRule, int playerNum)
    {
        GameObject player = GameObject.Find("Player" + playerNum);
        GameObject units = player.transform.FindChild("Units").gameObject;
        UnitStatusHandler[] ushs = units.GetComponentsInChildren<UnitStatusHandler>();

        foreach (UnitStatusHandler ush in ushs)
            ush.applyEffects(activationRule);
    }

    public TurnPhase nextPhase()
    {
        turnController.nextPhase();
        bottomPanelController.changePanels();

        if (data.selectedUnit != null)
            deselectUnit();

        return turnController.getCurrPhase();
    }
    
    public void selectUnit(GameObject unit)
    {
        if (data.selectedUnit != null)
            cancelMove();
        
        data.selectedUnit = unit;

        bottomPanelController.changePanels();

        fieldController.highlightWalkables();
    }
    

    public void deselectUnit()
    {
        data.selectedUnit = null;
        bottomPanelController.changePanels();
        fieldController.forgetWalkables();
    }

    public void plotMove(GameObject unit, GameObject tile)
    {
        UnitController uc = unit.GetComponent<UnitController>();

        Vector2 unitLocation = VectorUtil.gridLock(VectorUtil.convertVect3To2(unit.transform.position));
        Vector2 destination = VectorUtil.convertVect3To2(tile.transform.position);
        List<Vector2> movePath = MovementUtil.pathfind(unitLocation, destination);
        List<Vector2> highlightPath = MovementUtil.pathfind(uc.currentPosition, destination);
        GameObject occupant = data.map[destination].unit;

        if (highlightPath.Count - 1 > uc.movement || // if shortest path length exceeds unit's movement
            occupant != null && occupant != unit) // if space is occupied by another unit
            return;
            
        fieldController.plotPath(highlightPath);

        List<Vector3> vect3Path = getVect3Path(movePath);

        uc.setPath(vect3Path);
    }

    private List<Vector3> getVect3Path(List<Vector2> path)
    {
        List<Vector3> output = new List<Vector3>();
        foreach (Vector2 node in path)
        {
            GameObject topTile = data.map[node].topTile;
            output.Add(topTile.transform.position + Vector3.up);
        }
        return output;
    }

    public void confirmMove()
    {
        GameObject selectedUnit = data.selectedUnit;
        UnitController selectedUnitController = selectedUnit.GetComponent<UnitController>();
        Vector2 selectedUnitOldPosition = selectedUnitController.currentPosition;
        Vector2 selectedUnitNewPosition = VectorUtil.gridLock(VectorUtil.convertVect3To2(selectedUnit.transform.position));

        data.map[selectedUnitOldPosition].unit = null;
        data.map[selectedUnitNewPosition].unit = selectedUnit;

        cmdDispatchers[data.turn].Move(selectedUnit,selectedUnitController.path);
        deselectUnit();
    }

    public void cancelMove()
    {
        GameObject selectedUnit = data.selectedUnit;
        UnitController uc = selectedUnit.GetComponent<UnitController>();
        Vector2 unitLocation = VectorUtil.gridLock(VectorUtil.convertVect3To2(selectedUnit.transform.position));
        Vector2 destination = uc.currentPosition;

        List<Vector2> path = MovementUtil.pathfind(unitLocation, destination);
        List<Vector3> vect3Path = getVect3Path(path);
        uc.setPath(vect3Path);

        deselectUnit();
    }


    public GameObject spawnUnit(int playerNum, long unitId, Vector3 location)
    {
        GameObject unit = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/Characters/baseUnit"));
        UnitLoader loader = unit.GetComponent<UnitLoader>();
        loader.unitId = unitId;
        loader.playerNum = playerNum;
        loader.setup(location);

        unit.transform.SetParent(GameObject.Find("Player"+playerNum).transform.FindChild("Units"));

        return unit;
    }


    public GameObject spawnStructures(int playerNum, long structureId, Vector3 location)
    {
        GameObject structure = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/Characters/baseUnit"));
        /*UnitLoader loader = unit.GetComponent<UnitLoader>();
        loader.unitId = unitId;
        loader.playerNum = playerNum;
        loader.setup(location);

        unit.transform.SetParent(GameObject.Find("Player" + playerNum).transform.FindChild("Units"));

        return unit;*/
        return null;
    }
}
