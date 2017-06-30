internal class ConsumableStats
{
    internal int _currHp;
    internal int _currSp;

    internal int currHp
    {
        get { return _currHp; }
        set {_currHp = (value<= maxHp)? value : maxHp;}
    }
    internal int maxHp { get; set; }


    internal int currSp
    {
        get { return _currSp; }
        set
        { _currSp = (value <= maxSp) ? value : maxSp; }
    }
    internal int maxSp { get; set; }
}
