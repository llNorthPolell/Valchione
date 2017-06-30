using UnityEngine;
using System.Collections.Generic;

public interface CommandDispatcher
{
    int PlayerNum { get; }
    IList<Command> Commands { get; }

    void Move(GameObject unit, List<Vector3> path);
}
