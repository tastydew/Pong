using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {

    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;
    public TextMeshProUGUI gameWinnerText;
	// Use this for initialization
	void Start () {
        gameWinnerText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        playerOneScore.text = GameController.playerOneScore.ToString();
        playerTwoScore.text = GameController.playerTwoScore.ToString();

        if (GameController.playerOneScore == 10)
        {
            gameWinnerText.text = "PLAYER ONE WINS!";
        }

        if (GameController.playerTwoScore == 10)
        {
            gameWinnerText.text = "PLAYER TWO WINS!";
        }
	}
}
