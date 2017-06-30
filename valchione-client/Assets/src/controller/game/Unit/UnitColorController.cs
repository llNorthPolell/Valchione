using UnityEngine;

public class UnitColorController : MonoBehaviour {

    private MeshRenderer unitMeshRenderer;

    void Start()
    {
        Transform model = (transform.childCount > 0)? transform.GetChild(0): null;
        Transform characterModel = (model != null) ? model.FindChild("Character") :null;
        unitMeshRenderer = (characterModel!=null)? characterModel.GetComponent<MeshRenderer>() : null;
        unitMeshRenderer.material.EnableKeyword("_EMISSION");
        
    }

    void Update()
    {
    }

    public void setToActiveColor()
    {
        unitMeshRenderer.material.SetColor("_EmissionColor", UnitColors.ACTIVE);
    }

    public void setToDisabledColor()
    {
        unitMeshRenderer.material.SetColor("_EmissionColor", UnitColors.DISABLED);
    }
}
