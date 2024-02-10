using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    //public GameObject playebutton;
    //public GameObject ExitButton;
    public GameObject HowToPlayPanel;
    public GameObject GamePanel;

    private void Start()
    {
        HowToPlayPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

        public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowtoPlay()
    {
        HowToPlayPanel.SetActive(true);
        GamePanel.SetActive(false);

    }
    public void HowtoPlayexit()
    {
        HowToPlayPanel.SetActive(false);
        GamePanel.SetActive(true);

    }

    public void GameExit()
    {
        Application.Quit();
    }

}
