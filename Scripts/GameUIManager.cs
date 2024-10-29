using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text player1ScoreText; // Text ?? hi?n th? ?i?m Player 1
    public Text player1LivesText; // Text ?? hi?n th? s? m?ng Player 1
    public Text player2ScoreText; // Text ?? hi?n th? ?i?m Player 2
    public Text player2LivesText; // Text ?? hi?n th? s? m?ng Player 2
    //public Image player1Image; // H�nh ?nh c?a Player 1
    //public Image player2Image; // H�nh ?nh c?a Player 2

    private int player1Score = 0; // ?i?m kh?i ??u Player 1
    private int player1Lives = 3; // S? m?ng kh?i ??u Player 1
    private int player2Score = 0; // ?i?m kh?i ??u Player 2
    private int player2Lives = 3; // S? m?ng kh?i ??u Player 2

    public Button pauseButton; // Tham chi?u ??n n�t Pause/Resume
    public Sprite pauseSprite; // Sprite cho n�t Pause
    public Sprite resumeSprite; // Sprite cho n�t Resume

    private bool isPaused = false;

    public int Player1Score
    {
        get { return player1Score; }
        set
        {
            player1Score = value;
            UpdateScoreText();
        }
    }

    // Getter v� Setter cho Player2Score
    public int Player2Score
    {
        get { return player2Score; }
        set
        {
            player2Score = value;
            UpdateScoreText();
        }
    }


    void Start()
    {
        UpdateScoreText();
        UpdateLivesText();
        UpdatePauseButtonSprite();
    }

    //public void UpdateCharacterImages(Sprite player1Sprite, Sprite player2Sprite)
    //{
    //    player1Image.sprite = player1Sprite; // C?p nh?t h�nh ?nh cho Player 1
    //    player2Image.sprite = player2Sprite; // C?p nh?t h�nh ?nh cho Player 2
    //}

    //public Sprite GetPlayer1Sprite()
    //{
    //    return player1Image.sprite; // Tr? v? h�nh ?nh c?a Player 1
    //}

    //public Sprite GetPlayer2Sprite()
    //{
    //    return player2Image.sprite; // Tr? v? h�nh ?nh c?a Player 2
    //}

    public void AddPlayer1Score(int points)
    {
        player1Score += points; // C?ng ?i?m cho Player 1
        UpdateScoreText();
    }

    public void RemovePlayer1Life()
    {
        player1Lives--; // Gi?m s? m?ng cho Player 1
        UpdateLivesText();

        if (player1Lives <= 0)
        {
            GameOver(); // G?i h�m game over n?u kh�ng c�n m?ng
        }
    }

    public void AddPlayer2Score(int points)
    {
        player2Score += points; // C?ng ?i?m cho Player 2
        UpdateScoreText();
    }

    public void RemovePlayer2Life()
    {
        player2Lives--; // Gi?m s? m?ng cho Player 2
        UpdateLivesText();

        if (player2Lives <= 0)
        {
            GameOver(); // G?i h�m game over n?u kh�ng c�n m?ng
        }
    }

    private void UpdateScoreText()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score; // C?p nh?t ?i?m hi?n th? cho Player 1
        player2ScoreText.text = "Player 2 Score: " + player2Score; // C?p nh?t ?i?m hi?n th? cho Player 2
    }

    private void UpdateLivesText()
    {
        player1LivesText.text = "Player 1 Lives: " + player1Lives; // C?p nh?t s? m?ng hi?n th? cho Player 1
        player2LivesText.text = "Player 2 Lives: " + player2Lives; // C?p nh?t s? m?ng hi?n th? cho Player 2
    }


    public void TogglePause()
    {
        isPaused = !isPaused; // ??o ng??c tr?ng th�i t?m d?ng

        // T?m d?ng ho?c kh�i ph?c th?i gian
        Time.timeScale = isPaused ? 0 : 1;

        UpdatePauseButtonSprite(); // C?p nh?t sprite n�t
    }

    private void UpdatePauseButtonSprite()
    {
        // Thay ??i sprite c?a n�t t�y thu?c v�o tr?ng th�i
        pauseButton.image.sprite = isPaused ? resumeSprite : pauseSprite;
    }

    private void GameOver()
    {
        // Th?c hi?n h�nh ??ng khi tr� ch?i k?t th�c
        Debug.Log("Game Over");
        // B?n c� th? chuy?n sang c?nh Game Over ho?c hi?n th? menu
    }
}
