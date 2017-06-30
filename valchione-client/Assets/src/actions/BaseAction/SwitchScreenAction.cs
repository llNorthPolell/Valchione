using UnityEngine;
using System.Collections;


/**
* Used for switching between screens in a menu system.
*/
public abstract class SwitchScreenAction : OfflineSubmitAction {
    /** Body Panel (Central location where menus will be rendered)*/
    public GameObject body;

    /** Target screen; this action will switch to this screen*/
    protected GameObject screenOfInterest;


    protected void switchScreen(GameObject screenOfInterest)
    {
        closeBodyWindows();
        screenOfInterest.SetActive(true);
    }


    protected void closeBodyWindows()
    {
        foreach (Transform child in body.transform)
            child.gameObject.SetActive(false);
    }
}
