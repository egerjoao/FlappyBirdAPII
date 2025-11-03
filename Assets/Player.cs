using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform teto;

    [Header("Referências")]
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameHandle gameHandle; 
    [SerializeField] private AudioSource audioSource;

    [Header("Sons")]
    [SerializeField] private AudioClip somDoPulo;

    [Header("Skins")]
    [SerializeField] private Sprite[] skins;

    private bool isDead = false;

    private void Awake()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        if (animator == null) animator = GetComponent<Animator>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        if (gameHandle == null)
        {
            Debug.LogError("O GameHandle NÃO FOI CONECTADO no Inspetor do Player!");
        }
    }

    private void Start()
    {
        if (skins.Length > 0)
        {
            SetSkin(0);
        }
    }

    private void Update()
    {
        if (isDead) return;

        Pular();
        ChecarTeto();
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.velocity = Vector2.up * jumpSpeed;
            
            if (audioSource != null && somDoPulo != null)
            {
                audioSource.PlayOneShot(somDoPulo); 
            }
        }
    }

    private void ChecarTeto()
    {
        if (transform.position.y > teto.position.y)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    public void GameOver()
    {
        if (isDead) return;
        isDead = true;
        animator.SetBool("isDead", true);

        if (gameHandle != null)
        {
            gameHandle.GameOver();
        }
    }

    /// <summary>
    /// </summary>
    public void SetSkin(int index)
    {
        if (skins == null || skins.Length == 0)
        {
            Debug.LogWarning("Array de skins vazio!");
            return;
        }

        if (index < 0 || index >= skins.Length)
        {
            Debug.LogWarning("Índice de skin inválido!");
            return;
        }

        spriteRenderer.sprite = skins[index];
        animator.Rebind();
    }
}