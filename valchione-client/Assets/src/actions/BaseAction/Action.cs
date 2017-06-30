using UnityEngine;

/** Base class for GUI actions */
public abstract class Action : MonoBehaviour{

    /** The popup window for errors */
    private GameObject errorModal;
    protected ModalController errorModalController;


    /** The popup window for informative detail */
    private GameObject infoModal;
    protected ModalController infoModalController;
    

    protected abstract void init();

    void Awake()
    {
        initModals();
    }




    public void setModals(GameObject errorModal, GameObject infoModal)
    {
        this.errorModal = errorModal;
        this.infoModal = infoModal;
        initModals();
    }

    protected void initModals()
    {
        GameObject modalContainer = GameObject.Find("ModalContainer");
        errorModal = modalContainer.GetComponent<ModalContainer>().errorModal;
        infoModal = modalContainer.GetComponent<ModalContainer>().infoModal;

        if (errorModal!=null)
            errorModalController = errorModal.GetComponent<ModalController>();

        if (infoModal!=null)
            infoModalController = infoModal.GetComponent<ModalController>();
    }
    
    /** Triggers action */
    public abstract void execute();
}
