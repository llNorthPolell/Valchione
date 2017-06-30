using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAction : OnlineSubmitAction
{
    private string username = "";
    private string password = "";

    public InputField usernameField;
    public InputField passwordField;

    public Button loginBtn;

    protected override void setSubmitInformation()
    {
        url = BASEURL + "/login";
        onSubmitMessage = "Logging In...";
        disableSubmitBtnOnSubmit = true;
        submitBtn = loginBtn;
    }

    protected override void init()
    {
        username = usernameField.text;
        password = passwordField.text;
    }

    protected override bool fieldsValid()
    {
        return username != null && password != null
            && username.Length > 0 && password.Length > 0;
    }

    protected override void addFields(WWWForm form)
    {
        form.AddField(FormConstants.USERNAME, username);
        form.AddField(FormConstants.PASSWORD, password);
    }

    protected override string onError(int errorCode)
    {
        switch (errorCode)
        {
            case 400:
                return  "Invalid Username / Password...";
            default:
                return "Unknown Error...";
        }
    }

    protected override void onSuccess(string successWWWText)
    {
        PlayerDto p = JsonInputProcessor.createFromJson<PlayerDto>(successWWWText);
        PlayerSession.getInstance().playerDto = p;
        
        SceneManager.LoadScene("mainLoadingScreen");
    }

    protected override void handleInvalidFields()
    {
        if (username == null || username.Length == 0)
            errorModalController.DisplayMessage("Username required...");
        else if (password == null || password.Length == 0)
            errorModalController.DisplayMessage("Password required...");
    }
}
