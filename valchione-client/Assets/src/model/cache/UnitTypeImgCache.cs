using UnityEngine;
using System.Collections.Generic;

public class UnitTypeImgCache{
    private Dictionary<string, Sprite> typeImgs = new Dictionary<string, Sprite>();
    private static UnitTypeImgCache instance;

    private UnitTypeImgCache() {
        Sprite[] typeSprites = Resources.LoadAll<Sprite>("images/UnitTypes");

        foreach (Sprite typeSprite in typeSprites)
            typeImgs.Add(typeSprite.name, typeSprite);
    }

    public Sprite get(string key)
    {
        Sprite typeImg = null;
        typeImgs.TryGetValue(key, out typeImg);

        return typeImg;
    }


    public static UnitTypeImgCache getInstance()
    {
        if (instance == null)
            instance = new UnitTypeImgCache();

        return instance;
    }

}
