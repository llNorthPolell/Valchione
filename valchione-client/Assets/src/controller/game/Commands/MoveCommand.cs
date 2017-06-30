using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveCommand : Command
{
    public GameObject Unit { get; set; }
    public List<Vector3> Path { get; set; }
    
    public MoveCommand(GameObject unit, List<Vector3> path)
    {
        Unit = unit;
        Path = path;
    }
    
    public void execute()
    {
        UnitController unitController = Unit.GetComponent<UnitController>();
        unitController.confirmMove();
    }
}
