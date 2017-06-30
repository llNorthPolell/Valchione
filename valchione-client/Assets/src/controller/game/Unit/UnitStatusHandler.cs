using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Manages ailments and buffs on each unit.
/// </summary>
public class UnitStatusHandler : MonoBehaviour {
    private Dictionary<ActivationRule, List<Effect>> ailments;
    private Dictionary<ActivationRule, List<Effect>> buffs;

    private List<Effect> perm;

	void Start () {
        
	}
	
    public void init()
    {
        ailments = new Dictionary<ActivationRule, List<Effect>>();
        buffs = new Dictionary<ActivationRule, List<Effect>>();
        perm = new List<Effect>();

        foreach (ActivationRule a in Enum.GetValues(typeof(ActivationRule))) { 
            ailments.Add(a, new List<Effect>());
            buffs.Add(a, new List<Effect>());
        }
    }
    /// <summary>
    /// Updates ailments and buffs with the same activation rule
    /// </summary>
    /// <param name="activationRule"> When the statuses will be applied </param>
    public void applyEffects(ActivationRule activationRule)
    {
        applyEffects(activationRule, EffectType.AILMENT);
        applyEffects(activationRule, EffectType.BUFF);
    }

    private void applyEffects(ActivationRule activationRule, EffectType effectType)
    {
        List<Effect> involvedStatuses = (effectType==EffectType.AILMENT)? ailments[activationRule]:buffs[activationRule];
        List<Effect> expiredStatuses = new List<Effect>();

        foreach (Effect e in involvedStatuses)
        {
            e.applyEffect();
            if (e.age == e.duration) expiredStatuses.Add(e);
        }

        foreach (Effect e in expiredStatuses)
            involvedStatuses.Remove(e);
    }

    /// <summary>
    /// Removes all buffs from this unit
    /// </summary>
    public void dispelBuffs()
    {
        buffs.Clear();
    }

    /// <summary>
    /// Removes all ailments from this unit
    /// </summary>
    public void dispelAilments()
    {
        ailments.Clear();
    }


    /// <summary>
    /// Adds a new status to the unit if it does not have it already. Otherwise, it will replace the status.
    /// </summary>
    /// <param name="e"> New Effect </param>
    public void addEffect(Effect e)
    {
        Debug.Log(ailments);
        List<Effect> affectedList = (e.effectType == EffectType.AILMENT) ? ailments[e.activationRule] : buffs[e.activationRule];

        bool exists = false;

        foreach (Effect effect in affectedList)
            if (effect.Equals(e)) {
                exists = true;
                break;
            }

        if (exists)
            affectedList.Remove(e);
            
        affectedList.Add(e);
    }


    /// <summary>
    /// Removes the specified effect
    /// </summary>
    public void removeEffect(Effect e)
    {
        List<Effect> affectedList = (e.effectType == EffectType.AILMENT) ? ailments[e.activationRule] : buffs[e.activationRule];

        affectedList.Remove(e);
    }


}
