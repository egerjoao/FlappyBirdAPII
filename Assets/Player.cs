using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform teto;

    [Header("Referências")]
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Animator animator;
    [SerializeField] private GameHandle gameHandle;

    [Header("Skins")]
    [SerializeField] private RuntimeAnimatorController[] skins;

    private bool isDead = false;

    private void Awake()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();

        if (gameHandle == null)
        {
            Debug.LogError("O GameHandle NÃO FOI CONECTADO no Inspetor do Player!");
        }
    }

    private void Start()
    {
        int savedIndex = SkinManager.GetSavedSkin();
        SetSkin(savedIndex);
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

    public void SetSkin(int index)
    {
        if (index >= 0 && index < skins.Length)
        {
            animator.runtimeAnimatorController = skins[index];
        }
    }
}
