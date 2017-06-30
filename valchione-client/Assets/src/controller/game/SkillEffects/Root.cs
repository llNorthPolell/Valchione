using UnityEngine;
using System.Collections;

public class Root : Effect {

    public Root(GameObject unit, int duration) : base(unit)
    {
        this.effectName = "Root";
        this.effectType = EffectType.AILMENT;
        this.duration = duration;
        this.activationRule = ActivationRule.TURN_START;
    }

    protected override void tick()
    {
        unit.GetComponent<UnitController>().moved = true;

        Debug.Log(unit + " is rooted for " + (this.duration - this.age) + " more turns...");
    }
}
