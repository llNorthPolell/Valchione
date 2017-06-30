using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurrenderAction : OfflineSubmitAction
{
    protected override void init()
    {
    }

    protected override void setSubmitInformation()
    {
        submitBtn = GetComponent<Button>();
    }

    protected override void transitionActions()
    {
        SceneManager.LoadScene("mainScreen");
    }
}
