using UnityEngine;
using System.Collections.Generic;

/// <summary>
///  Handles unit states. States are mainly used for animations.
///  A unit could be: IDLE, MOVING, ATTACKING, SKILL, GUARDING, DEAD.
/// </summary>
public class UnitStateController {
    private GameData data;
    public UnitState state { get; private set; }

    
    public UnitStateController()
    {
        data = Camera.main.GetComponent<GameData>();
        state = UnitState.IDLE;
    }

    public void select()
    {
        state = (data.phase == TurnPhase.BATTLE && data.turn == 1) ? UnitState.MOVING : state;

        Debug.Log((state == UnitState.MOVING) ? "MOVING" : "IDLE" );
            
    }

    public void deselect()
    {
        idle();
    }

    public void move()
    {
        state = UnitState.MOVING;
    }

    public void idle()
    {
        state = UnitState.IDLE;
    }

    public void guard()
    {
        state = UnitState.GUARDING;
    }

    public void attack()
    {
        state = UnitState.ATTACKING;
    }
}
