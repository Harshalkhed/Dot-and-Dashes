using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public string targetSceneName; // Name of the scene to load
    [SerializeField]
    private GameObject startPanel = null;
    [SerializeField]
    private GameObject PlayCanvas = null;
    public void LoadPanel()
    {
        startPanel.SetActive(true);
        PlayCanvas.SetActive(false);
    }
}
