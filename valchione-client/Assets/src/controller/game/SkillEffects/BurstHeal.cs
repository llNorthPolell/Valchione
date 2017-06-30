using UnityEngine;

public class BurstHeal : InstantEffect
{
    public int healAmount { get; private set; }

    public BurstHeal (GameObject unit, int healAmount) : base(unit, "BurstHeal")
    {
        this.healAmount = healAmount;
    }

    public override void applyEffect()
    {
        unit.GetComponent<UnitController>().unitData.conStats.currHp += healAmount;

        GameObject healEffect = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/VisualEffects/HealEffect/HealEffect"));
        healEffect.transform.position = unit.transform.position;
        healEffect.transform.SetParent(unit.transform, true);
    }
}
