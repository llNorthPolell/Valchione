using UnityEngine;

public class BottomPanelController : MonoBehaviour {

    public GameObject prepPanel;
    public GameObject battlePanel;
    public GameObject unitPanel;
    public GameObject moveBtnPanel;

    private StatsPanelController statsPanelController;

    private GameData data;
    private int playerNum = 1;
    
	// Use this for initialization
	void Start () {
        prepPanel = transform.GetChild(0).gameObject;
        battlePanel = transform.GetChild(1).gameObject;
        unitPanel = transform.GetChild(2).gameObject;


        data = Camera.main.GetComponent<GameData>();
        statsPanelController = unitPanel.GetComponent<StatsPanelController>();
        changePanels();
    }
	
	// Update is called once per frame
	void Update () {
    }


    public void changePanels()
    {
        closeAllBottomPanels();
        GameObject selectedUnit = data.selectedUnit;
        UnitController selectedUnitController = (selectedUnit!=null)?selectedUnit.GetComponent<UnitController>() : null;

        if (selectedUnit == null)
        {
            if (data.phase == TurnPhase.PREPARATION)
                prepPanel.SetActive(true);
            else if (data.phase == TurnPhase.BATTLE)
                battlePanel.SetActive(true);
        }
        else
        {
            unitPanel.SetActive(true);
            statsPanelController.setStats();
            
            moveBtnPanel.SetActive(data.phase == TurnPhase.BATTLE 
                && data.turn == data.playerNum
                && selectedUnitController.ownerNum == data.playerNum
                && !selectedUnitController.moved 
                );
        }
    }

    public void closeAllBottomPanels()
    {
        unitPanel.SetActive(false);
        prepPanel.SetActive(false);
        battlePanel.SetActive(false);
    }
}
