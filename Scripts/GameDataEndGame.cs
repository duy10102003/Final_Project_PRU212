using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameDataEndGame : MonoBehaviour
{
    public int scorePlayer1;
    public int scorePlayer2;
    //public bool player1IsWin;
    //public bool player2IsWin;
    public static GameDataEndGame Instance;
    private void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
