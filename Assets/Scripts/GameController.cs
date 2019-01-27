using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    public static int playerOneScore = 0;
    [SerializeField]
    public static int playerTwoScore = 0;
    public Button playAgainButton;
    public Button quitButton;

    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void EnableUIButtons()
    {
        playAgainButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    void DisableUIButtons()
    {
        playAgainButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    void PlayAgain()
    {
        SceneManager.LoadSceneAsync(0);
        playerOneScore = 0;
        playerTwoScore = 0;
        DisableUIButtons();
    }

    void Update()
    {
        if (playerOneScore == 10 || playerTwoScore == 10)
        {
            EnableUIButtons();
        }
        else
        {
            DisableUIButtons();
        }
    }

}
