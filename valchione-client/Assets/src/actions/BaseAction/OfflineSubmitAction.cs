using UnityEngine.UI;

/** Used for handling a button click without needing data from the server */
public abstract class OfflineSubmitAction : OfflineAction
{
    /** message displayed when the system is handling the transaction */
    protected string onSubmitMessage;

    /** set to true if button should be disabled while the system is handling the transaction */
    protected bool disableSubmitBtnOnSubmit;

    /** button that will trigger this action */
    protected Button submitBtn;

    /** Set onSubmitMessage : string, disableSubmitBtnOnSubmit : bool, submitBtn : Button  */
    protected abstract void setSubmitInformation();

    /** Describe what will happen when the button is pressed here */
    protected abstract void transitionActions();

    void Start()
    {
        setSubmitInformation();
        submitBtn.onClick.AddListener(() => execute());
    }

    public override void execute()
    {
        initModals();
        init();

        submit();
    }

    /** Handles the transaction */
    public void submit()
    {
        if (disableSubmitBtnOnSubmit)
            submitBtn.enabled = false;

        transitionActions();

        if (disableSubmitBtnOnSubmit)
            submitBtn.enabled = true;
    }
   
}
