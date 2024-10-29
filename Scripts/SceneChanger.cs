using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SelectCharacter()
    {
        SceneManager.LoadScene("SelectCharacter");
    }
   
    public void Bomberman()
    {
        SceneManager.LoadScene("Bomberman");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame"); 
    }
}
