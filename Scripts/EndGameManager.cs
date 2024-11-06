using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text winnerText;

    void Start()
    {

        int player1Score = GameDataEndGame.Instance.scorePlayer1;
        int player2Score = GameDataEndGame.Instance.scorePlayer2;


        player1ScoreText.text = "Player 1 Score: " + player1Score;
        player2ScoreText.text = "Player 2 Score: " + player2Score;


        if (player1Score > player2Score)
        {
            winnerText.text = "Winner: Player 1!";
        }
        else if (player2Score > player1Score)
        {
            winnerText.text = "Winner: Player 2!";
        }
        else
        {
            winnerText.text = "It's a Tie!";
        }
    }

    public void RestartGame()
    {

        SceneManager.LoadScene("Bomberman");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
