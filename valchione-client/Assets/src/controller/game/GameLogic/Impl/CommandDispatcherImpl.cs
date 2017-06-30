using UnityEngine;
using System.Collections.Generic;

public class CommandDispatcherImpl : CommandDispatcher
{

    public IList<Command> Commands { get; private set; }
    public int PlayerNum { get; private set; }
    private Command LastCommand;

    public CommandDispatcherImpl(int playerNum)
    {
        Commands = new List<Command>();
        PlayerNum = playerNum;
    }

    public void Move(GameObject unit, List<Vector3> path)
    {
        LastCommand = new MoveCommand(unit, path);
        Commit();
    }

    private void Commit()
    {
        LastCommand.execute();
        Commands.Add(LastCommand);
    }
}

