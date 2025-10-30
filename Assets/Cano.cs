using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    [SerializeField] private float velocidadeCano = 5f;
    private void Update()
    {
        Move();
        if(transform.position.x < -8f) Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(Time.deltaTime * velocidadeCano * Vector2.left);
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     var bird = other.gameObject.GetComponent<Player>();
    //     if (bird == null) return;

    //     bird.GameOver();
    // }
}
