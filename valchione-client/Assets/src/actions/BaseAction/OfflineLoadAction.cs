
public abstract class OfflineLoadAction : OfflineAction
{
    protected abstract void loadFromCache();
    protected abstract void otherActions();

    void Start()
    {
        init();
        execute();
    }

    public void reload()
    {
        init();
        execute();
    }

    // Checks if player has session
    public bool checkPlayerSession()
    {
        if (PlayerSession.getInstance().playerDto == null)
        {
            errorModalController.DisplayMessage("Please Log In Again...", "LoginScreen");
            return false;
        }
        return true;
    }

    
    public override void execute()
    {
        initModals();
        if (checkPlayerSession())
        {
            loadFromCache();

            otherActions();
        }
    }
}
