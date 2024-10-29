using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class CharacterSelection : MonoBehaviour
{
    public Image[] characterImages; 
    public Image arrow1; 
    public Image arrow2; 
    public int player1Selection = 0; 
    public int player2Selection = 1; 

    private bool player1Confirmed = false; 
    private bool player2Confirmed = false;

    //public GameUIManager scoreboardManager;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        HandlePlayer1Input();
        HandlePlayer2Input();
        CheckIfBothPlayersConfirmed(); 
    }

    void HandlePlayer1Input()
    {
        if (!player1Confirmed) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                player1Selection = Mathf.Max(0, player1Selection - 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                player1Selection = Mathf.Min(characterImages.Length - 1, player1Selection + 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player1Selection != player2Selection) 
                {
                    ConfirmSelection(1);
                }
            }
        }
    }

    void HandlePlayer2Input()
    {
        if (!player2Confirmed) 
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player2Selection = Mathf.Max(0, player2Selection - 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player2Selection = Mathf.Min(characterImages.Length - 1, player2Selection + 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (player2Selection != player1Selection) 
                {
                    ConfirmSelection(2);
                }
            }
        }
    }

    void ConfirmSelection(int player)
    {
        if (player == 1)
        {
            player1Confirmed = true;
            Debug.Log("Player 1 ch?n nhân v?t: " + characterImages[player1Selection].name);
            // C?p nh?t hình ?nh trong b?ng ?i?m cho Player 1
            //scoreboardManager.UpdateCharacterImages(characterImages[player1Selection].sprite, scoreboardManager.GetPlayer2Sprite());
        }
        else
        {
            player2Confirmed = true;
            Debug.Log("Player 2 ch?n nhân v?t: " + characterImages[player2Selection].name);
            // C?p nh?t hình ?nh trong b?ng ?i?m cho Player 2
            //scoreboardManager.UpdateCharacterImages(scoreboardManager.GetPlayer1Sprite(), characterImages[player2Selection].sprite);
        }
    }

    void CheckIfBothPlayersConfirmed()
    {
        if (player1Confirmed && player2Confirmed)
        {
            
            SceneManager.LoadScene("Bomberman"); 
        }
    }

    void UpdateSelection()
    {
      
        for (int i = 0; i < characterImages.Length; i++)
        {
            characterImages[i].color = (i == player1Selection || i == player2Selection) ? Color.gray : Color.white;
        }

        
        arrow1.transform.position = characterImages[player1Selection].transform.position + new Vector3(0, 140, 0); 

        
        arrow2.transform.position = characterImages[player2Selection].transform.position + new Vector3(0, 140, 0); 
    }
}
