using UnityEngine;

public class TileColorController : MonoBehaviour {
    private Color startColor;
    private Color hoverColor;
    private Color highlightColor;
    private Color invalidColor;
    private Color walkedColor;

    private bool highlighted;
    private bool invalid;
    private bool accessible;

    private Renderer gameObjectRenderer;

	// Use this for initialization
	void Start () {
        gameObjectRenderer = GetComponent<Renderer>();
        startColor = gameObjectRenderer.material.color;
        hoverColor = Color.cyan;
        highlightColor = Color.blue;
        invalidColor = Color.red;
        walkedColor = Color.yellow;
        highlighted = false;
        invalid = false;
        accessible = false;
	}
	

    void OnMouseEnter()
    {
        if (!InputReceiver.pointingAtUI())
            gameObjectRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (accessible)
            gameObjectRenderer.material.color = walkedColor;
        else
        {
            if (highlighted)
                gameObjectRenderer.material.color = highlightColor;
            else if (invalid)
                gameObjectRenderer.material.color = invalidColor;
            else
                reset();
        }


    }



    public void highlight()
    {
        gameObjectRenderer.material.color = highlightColor;
        highlighted = true;
    }

    public void reset()
    {
        gameObjectRenderer.material.color = startColor;
        highlighted = false;
        invalid = false;
        accessible = false;
    }

    public void invalidate()
    {
        gameObjectRenderer.material.color = invalidColor;
        invalid = true;
    }

    public void markWalked()
    {
        gameObjectRenderer.material.color = walkedColor;
        accessible = true;
    }

    
}
