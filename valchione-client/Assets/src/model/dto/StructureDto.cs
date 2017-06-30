using UnityEngine;

[System.Serializable]
public class StructureDto : IStorable
{
    public long structureId;
    public string location;
    public int ownedBy;

    public static StructureDto createFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<StructureDto>(jsonString);
    }
}
