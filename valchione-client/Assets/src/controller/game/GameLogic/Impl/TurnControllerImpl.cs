using UnityEngine;

public class TurnControllerImpl : TurnController
{
    private GameData data;
    private bool debugMode = true;
    public TurnControllerImpl()
    {
        data = Camera.main.GetComponent<GameData>();
        data.turn = 1;
        data.phase = TurnPhase.PREPARATION;
    }

    public TurnPhase nextPhase()
    {
        data.phase++;
        Debug.Log("Next Phase" + data.phase);
        return data.phase;
    }

    public int nextTurn()
    {
        data.phase = TurnPhase.PREPARATION;
        data.turn++;

        if (data.turn > data.numOfPlayers)
            data.turn = 1;

        Debug.Log("Next Turn : " + data.turn);

        if (debugMode)
            if (data.turn != 1)
                nextTurn();
        return data.turn;
    }

    public int getCurrTurn()
    {
        return data.turn;
    }

    public TurnPhase getCurrPhase()
    {
        return data.phase;
    }
}
