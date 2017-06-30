using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Use on submit button for a form
public abstract class OnlineSubmitAction : OnlineAction
{
    protected bool disableSubmitBtnOnSubmit;
    protected Button submitBtn;
    protected string onSubmitMessage;

    // Forces child to set above Submit Information
    protected abstract void setSubmitInformation();

    
    void Start()
    {
        setSubmitInformation();
        submitBtn.onClick.AddListener(() => execute());
    }

    public override void execute()
    {
        initModals();
        init();

        StartCoroutine("Submit");
    }

    IEnumerator Submit()
    {
        if (fieldsValid())
        {
            infoModalController.DisplayMessage(onSubmitMessage);

            if (disableSubmitBtnOnSubmit)
                submitBtn.enabled = false;
            WWWForm form = new WWWForm();

            addFields(form);

            WWW www = new WWW(url, form);

            yield return www;

            infoModalController.closeModal();

            if (www.error != null)
            {
                string error = www.error;
                string errorCodeStr = error.Substring(0, 3);
                int errorCode = 0;
               
                Debug.Log(error);
                if (!int.TryParse(errorCodeStr, out errorCode))
                    error = "Connection Error";
                else
                    error = onError(errorCode);
                
                errorModalController.DisplayMessage(error);

                if (disableSubmitBtnOnSubmit)
                    submitBtn.enabled = true;
            }
            else
                onSuccess(www.text);

            
        }
        else
            handleInvalidFields();
    }
}
