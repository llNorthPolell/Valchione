using UnityEngine;
using System.Collections;

public abstract class InstantEffect : Effect {

	public InstantEffect(GameObject unit, string effectName) : base (unit)
    {
        this.effectName = effectName;
    }

    public abstract new void applyEffect();

    protected override void tick() { }
}
