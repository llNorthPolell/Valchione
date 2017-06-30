public interface DamageCalculator {
    int RawDamage { get; }
    bool IsCrit { get; }
    int FinalDamage { get; }

    int calcDmg(DamageType dmgType);
}
