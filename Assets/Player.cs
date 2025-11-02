using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 5f;  
    [SerializeField] private Transform teto;
    private Rigidbody2D _rb2D;
    [SerializeField] private GameHandle gameHandle; 
    
    private bool isDead = false;   

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        if (gameHandle == null)
        {
            Debug.LogError("GameHandle NÃO FOI CONECTADO no Inspetor do Player!");
        }
    }

    private void Update()
    {
        if (isDead) return;
        Pular();
        SubiuDemais();
    }

    private void SubiuDemais()
    {
        if(transform.position.y > teto.position.y) 
        {
            GameOver();
        }
    }

    private void Pular()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        _rb2D.velocity = Vector2.up * jumpSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    public void GameOver()
    {
        if (isDead) return;
        isDead = true;

        if (gameHandle != null)
        {
            gameHandle.GameOver();
        }

        Debug.Log("Game Over");
    }
}