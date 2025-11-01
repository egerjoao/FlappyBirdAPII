using UnityEngine;

public class MovimentoCano : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;

    private float pontoDeDestruicaoX = -10f;

    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (transform.position.x < pontoDeDestruicaoX)
        {
            Destroy(gameObject);
        }
    }
}