using UnityEngine;
using System.Collections.Generic;

public interface FieldController {
    void generateMap(MissionDto missionDto);
    void highlightWalkables();
    void forgetWalkables();
    void plotPath(List<Vector2> path);
    void resetPath();
}
