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

    //public PlayerSpawner playerSpawner;
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
                player1Selection = Mathf.Max(0, player1Selection - 1); // Giảm lựa chọn của Player 1
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                player1Selection = Mathf.Min(characterImages.Length - 1, player1Selection + 1); // Tăng lựa chọn của Player 1
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
                player2Selection = Mathf.Max(0, player2Selection - 1); // Giảm lựa chọn của Player 2
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player2Selection = Mathf.Min(characterImages.Length - 1, player2Selection + 1); // Tăng lựa chọn của Player 2
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
        int selectedPrefabIndex = 0;
        if (player == 1)
        {
            // Kiểm tra tên của hình ảnh Player 1 đã chọn
            if (characterImages[player1Selection].name == "Character1")
            {
                selectedPrefabIndex = 0; // Chọn element0 (tương ứng với character1)
            }
            else if (characterImages[player1Selection].name == "Character2")
            {
                selectedPrefabIndex = 1; // Chọn element1 (tương ứng với character2)
            }
            else if (characterImages[player1Selection].name == "Character3")
            {
                selectedPrefabIndex = 2; // Chọn element1 (tương ứng với character2)
            }
            else if (characterImages[player1Selection].name == "Character4")
            {
                selectedPrefabIndex = 3; // Chọn element1 (tương ứng với character2)
            }
            

            player1Confirmed = true;
            Debug.Log("Player 1 chọn nhân vật: " + characterImages[player1Selection].name);
            Debug.Log(selectedPrefabIndex);
            //PlayerSpawner.Instance.SpawnPlayerWithSelection(1, selectedPrefabIndex);

            GameDataNgu.Instance.player1 = selectedPrefabIndex;

            Debug.Log("Duy ngu vai ca cut " + GameDataNgu.Instance.player1);

        }
        else if (player == 2)
        {
            
            if (characterImages[player2Selection].name == "Character1")
            {
                selectedPrefabIndex = 4; 
            }
            else if (characterImages[player2Selection].name == "Character2")
            {
                selectedPrefabIndex = 5; 
            }else if (characterImages[player2Selection].name == "Character3")
            {
                selectedPrefabIndex = 6; 
            }
            else if (characterImages[player2Selection].name == "Character4")
            {
                selectedPrefabIndex = 7; 
            }
            

            player2Confirmed = true;
            Debug.Log("Player 2 chọn nhân vật: " + characterImages[player2Selection].name);
            Debug.Log(selectedPrefabIndex);
            

            // Truyền lựa chọn của Player 2 sang PlayerSpawner
            //PlayerSpawner.Instance.SpawnPlayerWithSelection(2, selectedPrefabIndex);
            GameDataNgu.Instance.player2 = selectedPrefabIndex;
            Debug.Log("Duy ngu vai ca cut " + GameDataNgu.Instance.player2);

        }
    }

    void CheckIfBothPlayersConfirmed()
    {
        if (player1Confirmed && player2Confirmed)
        {
            Debug.Log("Cả hai người chơi đã xác nhận, chuyển sang cảnh Bomberman.");
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
