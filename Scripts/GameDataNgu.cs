using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameDataNgu : MonoBehaviour
{
    public int player1;
    public int player2;
    public static GameDataNgu Instance;
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
