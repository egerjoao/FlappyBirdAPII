using UnityEngine;

public class BirdAnimationSpeed : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float normalSpeed = 1f;   // velocidade padrão
    [SerializeField] private float boostSpeed = 1.8f;  // velocidade quando pressiona espaço

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.speed = boostSpeed;
        else
            animator.speed = normalSpeed;
    }
}
