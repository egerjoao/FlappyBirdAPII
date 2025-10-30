using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var bird = other.gameObject.GetComponent<Player>();
        
        if(bird == null) return;
        
        bird.GameOver();
    }
}
