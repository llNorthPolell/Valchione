using UnityEngine;

/// <summary>
/// Converts player inputs into actions.
/// </summary>
public class InputProcessorImpl : InputProcessor {
    private CamController camController;
    private GameController gameController;
    private GameData data;
    private int playerNum;

    public InputProcessorImpl(InputReceiver inputReceiver)
    {
        gameController = Camera.main.GetComponent<DisplayGameScreenAction>().GameController;
        camController = new CamControllerImpl();

        data = Camera.main.GetComponent<GameData>();
        playerNum = data.playerNum;

        inputReceiver.endTurnButton.onClick.AddListener(() => gameController.nextTurn());
        inputReceiver.doneButton.onClick.AddListener(() => gameController.nextPhase());
        inputReceiver.cancelButton.onClick.AddListener(() => gameController.cancelMove());
        inputReceiver.moveButton.onClick.AddListener(() => gameController.confirmMove());
    }


    public void select(GameObject obj)
    {
        GameObject selectedUnit = data.selectedUnit;
        TurnPhase phase = data.phase;
        int turn = data.turn;
        UnitController selectedUnitController = (selectedUnit != null) ? selectedUnit.GetComponent<UnitController>() : null;

        if (phase == TurnPhase.PREPARATION || turn!=playerNum)
        {
            gameController.deselectUnit();

            if (SelectionUtil.isUnit(obj))
                gameController.selectUnit(obj);
                
        }
        else if (phase == TurnPhase.BATTLE)
        {
            if (SelectionUtil.isUnit(obj))
            {
                if (selectedUnit != null)
                {
                    if (turn == playerNum)
                        gameController.cancelMove();
                    gameController.deselectUnit();
                }

                gameController.selectUnit(obj);
            }
            else if (SelectionUtil.isTile(obj))
            {
                if (selectedUnit != null) {
                    if (selectedUnitController.ownerNum == playerNum)
                    {
                        if (!selectedUnitController.moved)
                            gameController.plotMove(selectedUnit, obj);
                        else
                            gameController.deselectUnit();
                    }
                    else
                        gameController.deselectUnit();
                }
            }

        }
    }

    public void moveCam(Direction dir)
    {
        camController.translate(dir);
    }



}
