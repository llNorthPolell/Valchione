using System;
using UnityEngine;

public class Stun : Effect
{

    public Stun(GameObject unit, int duration) : base(unit)
    {
        this.effectName = "Stun";
        this.effectType = EffectType.AILMENT;
        this.duration = duration;
        this.activationRule = ActivationRule.TURN_START;

        this.animation = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/VisualEffects/StunnedEffect/StunnedEffect"));
        animation.transform.position = unit.transform.position;
        animation.transform.SetParent(unit.transform, true);
    } 

    protected override void tick()
    {
        unit.GetComponent<UnitController>().confirmMove();
        
        Debug.Log(unit + " is stunned for " + (this.duration - this.age) + " more turns...");
    }
}
