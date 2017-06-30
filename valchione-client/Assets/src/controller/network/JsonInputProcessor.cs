using UnityEngine;
using System.Collections;

public class JsonInputProcessor{
    public static T createFromJson<T>(string jsonString) where T :IStorable
    {
        return JsonUtility.FromJson<T>(jsonString);
    }

    public static T[] createManyFromJson<T> (string jsonString) where T : IStorable
    {
        ArrayWrapper<T> arrayWrapper = JsonUtility.FromJson<ArrayWrapper<T>>(jsonString);
        return arrayWrapper.items;
    }

    [System.Serializable]
    private class ArrayWrapper<T>
    {
        public T[] items;
    }

}
