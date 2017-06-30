using UnityEngine;
using System.Collections;


// Use at beginning of new scene when data is required from the server
public abstract class OnlineLoadAction : OnlineAction {

    protected abstract void setLoadInformation();

    // Use this for initialization
    void Start()
    {
        setLoadInformation();
        execute();
    }

    public override void execute()
    {
        initModals();
        init();
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        if (fieldsValid())
        {
            WWWForm form = new WWWForm();

            addFields(form);

            WWW www = new WWW(url, form);
            yield return www;

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
            }
            else
                onSuccess(www.text);
        }
        else
            handleInvalidFields();
    }

   
}
