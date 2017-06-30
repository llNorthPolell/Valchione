using UnityEngine;
using System.Collections;
using System;

public class AttackCommand : Command
{
    public GameObject Attacker { get; private set; }
    public GameObject Target { get; private set; }
    public DamageType DamageType { get; private set; }

    public int Damage { get; private set; }
    public bool IsCrit { get; private set; }

    private DamageCalculator dmgCalc;

    public AttackCommand(GameObject attacker, GameObject target, DamageType dmgType)
    {
        Attacker = attacker;
        Target = target;
        DamageType = dmgType;

        dmgCalc = new DamageCalculatorImpl(Attacker, Target);
    }

    public void execute()
    {
        IsCrit = dmgCalc.IsCrit;
        Damage = dmgCalc.FinalDamage;

        UnitData targetStats = Target.GetComponent<UnitController>().unitData;

        targetStats.conStats.currHp -= Damage;

    }
}
