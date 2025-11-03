using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguia : MonoBehaviour
{
    private float velocidadeAguia = 5f;
    private float pontoDestruicaoX = -10f;

    public void DefinirVelocidade(float v)
    {
        velocidadeAguia = v;
    }

    void Update()
    {
        transform.position += Vector3.left * velocidadeAguia * Time.deltaTime;

        if (transform.position.x < pontoDestruicaoX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Player>().GameOver();
    }
}
