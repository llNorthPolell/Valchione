using UnityEngine;

[System.Serializable]
public class PlayerDto : IStorable
{
    
    public string username;
    public int playerLevel;
    public int playerExp;
    public int coins;
    public int gems;
    public int honorPoints;
    public int storyProgress;
    public int numOfDecks;

}