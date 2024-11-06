using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    [SerializeField]
    public GameUIManager gameUIManager;
    public int player;
    public bool activeSkill = false;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }
    public void Addhealth()
    {
        if (player == 1)
        {
            gameUIManager.GetComponent<GameUIManager>().AddLifeP1();
        }
        else
        {
            gameUIManager.GetComponent<GameUIManager>().AddLifeP2();
        }
    }
    public void AddScore(int score)
    {
        if (player == 1)
        {
            gameUIManager.GetComponent<GameUIManager>().AddPlayer1Score(score);
        }
        else
        {
            gameUIManager.GetComponent<GameUIManager>().AddPlayer1Score(score);
        }
    }
    
    public void Removehealth()
    { 
        if(!activeSkill){

            if (player == 1)
            {
                gameUIManager.GetComponent<GameUIManager>().RemovePlayer1Life();
            }
            else
            {
                gameUIManager.GetComponent<GameUIManager>().RemovePlayer2Life();
            }
        }


       
    }
    
    private void Update()
    {
        if (Input.GetKey(inputUp)) {
            SetDirection(Vector2.up, spriteRendererUp);
        } else if (Input.GetKey(inputDown)) {
            SetDirection(Vector2.down, spriteRendererDown);
        } else if (Input.GetKey(inputLeft)) {
            SetDirection(Vector2.left, spriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            SetDirection(Vector2.right, spriteRendererRight);
        } else {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = speed * Time.fixedDeltaTime * direction;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion")) {
            DeathSequence();
            Debug.Log("Va cham voi bom r");
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
        Debug.Log("Va cham voi bom r");
    }

    private void OnDeathSequenceEnded()
    {
        Debug.Log("Va cham voi bom r");
        gameObject.SetActive(false);
        GameManager.Instance.CheckWinState();
    }
    public void SetDisable()
    {
        this.enabled = false;
    }
    public void SetEnable()
    {
        this.enabled = true;
    }
}
