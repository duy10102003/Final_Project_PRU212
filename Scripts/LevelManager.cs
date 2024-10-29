using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        
        int player1Character = PlayerPrefs.GetInt("Player1Character");
        int player2Character = PlayerPrefs.GetInt("Player2Character");

       
        Debug.Log("Player 1 ?ã ch?n nhân v?t: " + player1Character);
        Debug.Log("Player 2 ?ã ch?n nhân v?t: " + player2Character);

      
    }
}
