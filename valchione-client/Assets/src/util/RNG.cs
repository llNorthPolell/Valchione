using System;

public class RNG {
    public static Random rand = new Random();

	public static int GenInt(int min, int max)
    {
        return rand.Next(min, max) + 1;
    }
}
