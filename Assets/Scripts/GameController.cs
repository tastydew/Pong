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

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void PlayAgain()
    {
        SceneManager.LoadSceneAsync(0);
        playerOneScore = 0;
        playerTwoScore = 0;
        playAgainButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerOneScore == 10 || playerTwoScore == 10)
        {
            playAgainButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);

        }
        else
        {
            playAgainButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
        }
    }

}
