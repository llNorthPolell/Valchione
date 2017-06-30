using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModalController : MonoBehaviour
{

    public Text displayText;
    public Button okBtn;
    public float displayTime;
    public float fadeTime;
    
    GameObject modalWindow;

    private string redirect;
   
    void Awake()
    {
        modalWindow = this.gameObject;
        closeModal();
    }

    void Start()
    {
        if (okBtn!=null)
            okBtn.onClick.AddListener(() => closeModal());
    }

    public void DisplayMessage(string message)
    {
        modalWindow.SetActive(true);
        displayText.text = message;
       
    }

    public void DisplayMessage(string message, string redirect)
    {
        modalWindow.SetActive(true);
        displayText.text = message;
        this.redirect = redirect;
    }

    public void closeModal()
    {
        if (redirect != null)
            SceneManager.LoadScene(redirect);
        modalWindow.SetActive(false);

    }
}