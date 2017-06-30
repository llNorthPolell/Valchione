public interface TurnController {
    int nextTurn();
    TurnPhase nextPhase();
    int getCurrTurn();
    TurnPhase getCurrPhase();
}
