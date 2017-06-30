using UnityEngine;

public class UnitData  {
    public long unitId { get; private set; }
    public string unitName { get; private set; }
    public string unitType { get; private set; }

    internal BasicStats baseStats { get; private set; }
    internal BasicStats currStats { get; private set; }

    internal AdvancedStats advStats { get; private set; }
    internal ConsumableStats conStats { get; private set; }

    public Sprite fullSprite { get; private set;}
    public Sprite portrait { get; private set; }

    public UnitData (UnitData unitData)
    {
        unitId = unitData.unitId;
        unitName = unitData.unitName;
        unitType = unitData.unitType;

        baseStats = new BasicStats()
        {
            hp = unitData.baseStats.hp,
            str = unitData.baseStats.str,
            spr = unitData.baseStats.spr,
            agi = unitData.baseStats.agi,
            spd = unitData.baseStats.spd
        };

        initCurrStats();
        initAdvStats();

        string unitIdStr = unitId.ToString();

        if (unitId < 10)
            unitIdStr = "0" + unitIdStr;

        Sprite[] sprites = Resources.LoadAll<Sprite>("images/" + unitIdStr);
        fullSprite = sprites[0];
        portrait = sprites[1];
    }


    public UnitData(UnitDto unitDto)
    {
        unitId = unitDto.unitId;
        unitName = unitDto.unitName;
        unitType = unitDto.unitType;

        baseStats = new BasicStats()
        {
            hp = unitDto.hp,
            str = unitDto.str,
            spr = unitDto.spr,
            agi = unitDto.agi,
            spd = unitDto.spd
        };

        initCurrStats();
        initAdvStats();

        string unitIdStr = unitId.ToString();

        if (unitId < 10)
            unitIdStr = "0"+ unitIdStr;

        Sprite[] sprites = Resources.LoadAll<Sprite>("images/" + unitIdStr);
        fullSprite = sprites[0];
        portrait = sprites[1];
    }

    private void initCurrStats()
    {
        currStats = new BasicStats()
        {
            hp = baseStats.hp,
            str = baseStats.str,
            spr = baseStats.spr,
            agi = baseStats.agi,
            spd = baseStats.spd
        };
    }

    private void initAdvStats()
    {
        conStats = new ConsumableStats()
        {
            maxHp = baseStats.hp,
            currHp = baseStats.hp,
            maxSp = Mathf.RoundToInt(currStats.spr * StatModifierConstants.MAX_SP_MODIFIER),
            currSp = Mathf.RoundToInt(currStats.spr * StatModifierConstants.MAX_SP_MODIFIER)
        };
        
        updateAdvStats();
    }


    public void updateAdvStats()
    {
        advStats = new AdvancedStats()
        {
            pAtk = currStats.str,
            mAtk = currStats.spr,
            pDef = Mathf.RoundToInt(currStats.str * StatModifierConstants.PDEF_MODIFIER),
            mDef = Mathf.RoundToInt(currStats.str * StatModifierConstants.MDEF_MODIFIER),
            mSpd = currStats.spd,
            aSpd = currStats.spd,
            acc = Mathf.RoundToInt(currStats.agi * StatModifierConstants.ACC_MODIFIER),
            eva = Mathf.RoundToInt(currStats.agi * StatModifierConstants.EVA_MODIFIER),
            crit = Mathf.RoundToInt(currStats.agi * StatModifierConstants.CRIT_MODIFIER)
        };
    }

    public void updateConsuambleStat(int newValue, string statName)
    {
        int currMaxStatValue = 0;
        float percentageDiff = 0;
        int newCurrStatValue = 0;

        if (statName.Equals("HP"))
            currMaxStatValue = conStats.maxHp;
        else if (statName.Equals("SP"))
            currMaxStatValue = conStats.maxSp;
        else
            return;

        percentageDiff = ((newValue - currMaxStatValue)/ currMaxStatValue) +1;
        newCurrStatValue = Mathf.RoundToInt(conStats.currHp * percentageDiff);


        if (statName.Equals("HP"))
        {
            conStats.maxHp = newValue;
            conStats.currHp = newCurrStatValue;
        }
        else if (statName.Equals("SP"))
        {
            conStats.maxSp = newValue;
            conStats.currSp = newCurrStatValue;
        }

    }

}
