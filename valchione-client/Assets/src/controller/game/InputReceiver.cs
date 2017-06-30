using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputReceiver: MonoBehaviour {
    public Button endTurnButton;
    public Button doneButton;
    public Button cancelButton;
    public Button moveButton;

    private bool debugMode;
    private InputProcessor processor;

    // Use this for initialization
    void Start () {
        processor = new InputProcessorImpl(this);
        debugMode = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (debugMode)
        {
            if (Input.GetKey("a"))
                processor.moveCam(Direction.LEFT);
            
            if (Input.GetKey("w"))
                processor.moveCam(Direction.UP);
            
            if (Input.GetKey("s"))
                processor.moveCam(Direction.DOWN);
            
            if (Input.GetKey("d"))
                processor.moveCam(Direction.RIGHT);

            testControls();

            if (Input.GetMouseButtonUp(0) && !pointingAtUI())
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    processor.select(hit.transform.gameObject);
            }

        }
    }


    private void testControls()
    {
            
    }


    public static bool pointingAtUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
