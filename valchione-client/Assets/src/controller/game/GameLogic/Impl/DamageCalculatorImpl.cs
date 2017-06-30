using UnityEngine;
using System;

public class DamageCalculatorImpl : DamageCalculator
{
    public UnitData AttackerStats { get; private set; }
    public UnitData TargetStats { get; private set; }


    public int RawDamage { get; private set; }
    public bool IsCrit { get; private set; }
    public int FinalDamage { get; private set; }

    public DamageCalculatorImpl(GameObject attacker, GameObject target)
    {
        AttackerStats = attacker.GetComponent<UnitController>().unitData;
        TargetStats = target.GetComponent<UnitController>().unitData;
    }

       // dmg = (isCrit(attackerStats, targetStats)) ? dmg * 2 : dmg;
        
    public int calcDmg(DamageType dmgType)
    {
        calcRawDmg(dmgType);
        checkIsCrit();

        FinalDamage = RawDamage;
        FinalDamage = (IsCrit) ? FinalDamage * 2 : FinalDamage;

        return FinalDamage;
    }

    private void calcRawDmg(DamageType dmgType)
    {
        RawDamage = (dmgType == DamageType.PHYSICAL) ?
            AttackerStats.advStats.pAtk - TargetStats.advStats.pDef :
            AttackerStats.advStats.mAtk - TargetStats.advStats.mDef;
    }


    private void checkIsCrit()
    {
        IsCrit= RNG.GenInt(1, 100) < AttackerStats.advStats.crit;
    }

    
}
