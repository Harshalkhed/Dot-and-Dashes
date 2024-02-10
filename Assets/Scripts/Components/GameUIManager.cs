using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance { get; private set; }

    [SerializeField]
    private GameObject startPanel = null;
    [SerializeField]
    private Dropdown sizeXDropdown = null;
    [SerializeField]
    private Dropdown sizeYDropdown = null;
    [SerializeField]
    private GameObject GamePanel;
    [SerializeField]
    private GameObject player1InGameInfo = null;
    [SerializeField]
    private Image player1IconImage = null;
    [SerializeField]
    private Text player1NameText;
    [SerializeField]
    private Text player1ScoreText;
    [SerializeField]
    private Image playerWinIconImage;
    [SerializeField]
    private GameObject player2InGameInfo = null;
    [SerializeField]
    private Image player2IconImage = null;
    [SerializeField]
    private Text player2NameText ;
    [SerializeField]
    private Text player2ScoreText = null;

    [SerializeField]
    private GameObject playerInTurnIndicator = null;
    //[SerializeField]
    //private Text playerInTurnText = null;
    //[SerializeField]
    //private Image playerInTurnIconImage = null;

    [SerializeField]
    private GameObject gameOverPanel = null;
    [SerializeField]
    private Text gameOverText = null;
    [SerializeField]
    private TMP_InputField InputField1;
    [SerializeField]
    private TMP_InputField InputField2;
    [SerializeField]
    private ScrollRect scroll1;
    [SerializeField]
    private ScrollRect scroll2;
    [SerializeField]
    private GameObject Turnimage1;

    [SerializeField]
    private GameObject Turnimage2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }


    private void Start()
    {
        player1InGameInfo.SetActive(false);
        player2InGameInfo.SetActive(false);
        playerInTurnIndicator.SetActive(false);
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        
    }
    public void  PlayAgain()
    {
        
    }

    private void Update()
    {
        

    }

    
    


    public void SetPlayers(string p1, string p2,Sprite icon1,Sprite icon2)
    {
        //Debug.Log(p1 + p2);
        player1IconImage.sprite = icon1;
        player1NameText.text = p1;
        player1ScoreText.text = "0";

        player2IconImage.sprite = icon2;
        player2NameText.text = p2;
        player2ScoreText.text = "0";
    }

    public void UpdatePlayerInTurnPlayerScore()
    {
        if (GameManager.Instance.PlayerInTurn == GameManager.Instance.Player1)
        {
            player1ScoreText.text = $" {GameManager.Instance.PlayerInTurn.Score}";
        }
        else
        {
            player2ScoreText.text = $" {GameManager.Instance.PlayerInTurn.Score}";
        }
    }

    public void SetPlayerInTurn(Player playerInTurn)
    {
        //playerInTurnText.text = $"Turn for {playerInTurn.Name}";
        //playerInTurnIconImage.sprite = playerInTurn.Icon;
        if (playerInTurn == GameManager.Instance.Player1)
        {
            Turnimage1.SetActive(true);
            Turnimage2.SetActive(false);
        }
        else if (playerInTurn == GameManager.Instance.Player2)
        {
            Turnimage1.SetActive(false);
            Turnimage2.SetActive(true);
        }

    }

    public void ShowGameOver(Player winner)
    {
        if (winner == null)
        {
            // Draw
            gameOverText.text = $"It is a Draw";
        }
        else
        {
            gameOverText.text = $"Winner is {winner.Name} with a score of {winner.Score}";

            // Set the sprite of the playerIconImage to the winning player's icon
            playerWinIconImage.sprite = winner.Icon;
        }

        gameOverPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    public void ShowInGamePlayersInfo(bool show)
    {

    }

    public void MainemnuExit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Hidewindow()
    {
        //window.SetActive(false);
        startPanel.SetActive(true);
    }

    public void OnStartGame()
    {
        int sizeX = int.Parse(sizeXDropdown.options[sizeXDropdown.value].text);
        int sizeY = int.Parse(sizeYDropdown.options[sizeYDropdown.value].text);

        string player1Name = InputField1.text;
        string player2Name = InputField2.text;

        // Get all images in the scroll view
        Image[] images1 = scroll1.content.GetComponentsInChildren<Image>();
        Image[] images2 = scroll2.content.GetComponentsInChildren<Image>();

        // Get the index of the selected sprite
        int selectedSpriteIndex1 = GetSelectedSpriteIndex(scroll1, images1[0].sprite);
        int selectedSpriteIndex2 = GetSelectedSpriteIndex(scroll2, images2[0].sprite);

        // Use the index to get the selected sprite
        Sprite icon1 = images1[selectedSpriteIndex1].sprite;
        Sprite icon2 = images2[selectedSpriteIndex2].sprite;

        startPanel.SetActive(false);

        GameManager.Instance.StartGame(sizeX, sizeY, player1Name, player2Name, icon1, icon2);

        player1InGameInfo.SetActive(true);
        player2InGameInfo.SetActive(true);
        playerInTurnIndicator.SetActive(true);
    }

    private int GetSelectedSpriteIndex(ScrollRect scrollRect, Sprite selectedSprite)
    {
        HorizontalLayoutGroup layoutGroup = scrollRect.content.GetComponent<HorizontalLayoutGroup>();
        Image[] images = layoutGroup.GetComponentsInChildren<Image>();

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].sprite == selectedSprite)
            {
                return i;  // Return the index of the image with the selected sprite
            }
        }

        return -1;  // Return -1 if the selected sprite is not found
    }


}
