using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    //public Text player1ScoreText; 
    //public Text player2ScoreText; 
    //public Text winnerText;

    //void Start()
    //{
    //    // L?y ?i?m s? t? ScoreboardManager
    //    int player1Score = GameUIManager.Player1Score;
    //    int player2Score = GameUIManager.Player2Score;

    //    // Hi?n th? ?i?m
    //    player1ScoreText.text = "Player 1 Score: " + player1Score;
    //    player2ScoreText.text = "Player 2 Score: " + player2Score;

    //    // Ki?m tra ai th?ng và c?p nh?t thông báo
    //    if (player1Score > player2Score)
    //    {
    //        winnerText.text = "Winner: Player 1!";
    //    }
    //    else if (player2Score > player1Score)
    //    {
    //        winnerText.text = "Winner: Player 2!";
    //    }
    //    else
    //    {
    //        winnerText.text = "It's a Tie!";
    //    }
    //}

    public void RestartGame()
    {
        
        SceneManager.LoadScene("Bomberman"); 
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}
