using UnityEngine;
using UnityEngine.UI;

public class DisplayEditDecksScreen : SwitchScreenAction
{
    public GameObject editDecks;
    public int deckIndex;

    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        onSubmitMessage = "Loading...";
        disableSubmitBtnOnSubmit = false;
        submitBtn = GetComponent<Button>();
    }

    protected override void transitionActions()
    {
        switchScreen(editDecks);
    }
}
