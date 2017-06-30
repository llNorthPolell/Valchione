using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenResources : MonoBehaviour {
    public string nextSceneName;
    public int progress { get; private set; }
    public Text loadingText;

    void Start()
    {
        progress = 0;
    }
    
    public void updateProgress(int advancement, string nextAction)
    {
        loadingText.text = nextAction;

        progress += advancement;

        if (progress == 100)
            SceneManager.LoadScene(nextSceneName);
    }

}
