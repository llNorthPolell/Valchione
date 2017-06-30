using UnityEngine;

public abstract class Effect {
    /// <summary>
    /// Name of the effect
    /// </summary>
    public string effectName { get; protected set; }


    /// <summary>
    /// Type of Effect (Ailment or Buff)
    /// </summary>
    public EffectType effectType { get; protected set; }


    /// <summary>
    /// When this effect will be applied (Turn start, turn end, on hit, etc.)
    /// </summary>
    public ActivationRule activationRule { get; protected set; }

    private int? _duration;

    public int? duration {
        get {return _duration;}
        protected set
        {
            _duration = value;
            age = 0;
        }
    }
    public int? age { get; private set; }

    /// <summary>
    /// Stores effect animation
    /// </summary>
    public GameObject animation { get; protected set; }


    private UnitStatusHandler unitStatusHandler;

    public GameObject unit { get; private set; }


    public Effect(GameObject unit)
    {
        this.unit = unit;
        unitStatusHandler = unit.GetComponent<UnitStatusHandler>();
        if (duration != null)
            age = 0;
    }

    /// <summary>
    /// Insert what this effect does to the unit in here.
    /// </summary>
    protected abstract void tick();


    /// <summary>
    /// Applies the effect to the unit.
    /// </summary>
    public void applyEffect()
    {
        if (duration != null)
        {
            age++;

            if (age == duration)
            {
                destroyAnimation();
                return;
            }
        }

        tick();

    }


    public void destroyAnimation()
    {
        if (animation!=null)
            GameObject.Destroy(animation);
    }
}
