using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Main Facade for controlling game units. 
/// </summary>
public class UnitController : MonoBehaviour, IMovable, ISelectable, ICombat {
    private const int SPEED = 10;

    public int ownerNum { get; set; }

    public UnitData unitData { get; private set; }
    public long unitId;
        
    public Direction faceDirection { get; set; }

    internal List<Vector3> path { get; private set; }

    public int movement { get; set; }
    public bool moved { get; set; }

    public Vector2 currentPosition{ get; private set; }

    internal UnitColorController unitColorController { get; private set; }
    internal UnitStateController unitStateController { get; private set; }

    public void init()
    {
        unitColorController = GetComponent<UnitColorController>();
        unitData = UnitDataStorage.getInstance().get(unitId);
        unitStateController = new UnitStateController();

        path = new List<Vector3>();
        faceDirection = Direction.DOWN;
        moved = false;
        currentPosition = VectorUtil.convertVect3To2(transform.position);


        movement = (unitData != null) ? unitData.advStats.mSpd : 0;
    }
    
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (path.Count > 0)
        {
            faceDirection =
                (path[0].x < transform.position.x) ? Direction.RIGHT :
                (path[0].x > transform.position.x) ? Direction.LEFT :
                (path[0].z < transform.position.z) ? Direction.UP :
                (path[0].z > transform.position.z) ? Direction.DOWN :
                faceDirection;

            transform.position = Vector3.MoveTowards(transform.position, path[0], Time.deltaTime * SPEED);
            updateRotation();
            if (path[0] == transform.position)
                path.Remove(path[0]);

            if (path.Count == 0)
                unitStateController.idle();
        }

	}

    public void updateRotation()
    {
        transform.localEulerAngles = new Vector3(0, ((int)faceDirection) * 90, 0);
    }

    public void select()
    {
        unitStateController.select();
    }

    public void deselect()
    {
        unitStateController.deselect();
    }

    public void setPath(List<Vector3> path)
    {
        if (!moved)
            this.path = path;
    }

    public void insertPathNode(Vector3 pathNode)
    {
        path.Add(pathNode);
    }

    public void confirmMove()
    {
        moved = true;
        unitColorController.setToDisabledColor();
        currentPosition = VectorUtil.convertVect3To2(transform.position);
    }

    public void refreshMove()
    {
        moved = false;
        unitColorController.setToActiveColor();
    }

    public void attack(ICombat target)
    {
        unitStateController.attack();
    }

    public void takeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public void guard()
    {
        unitStateController.guard();
    }
}
