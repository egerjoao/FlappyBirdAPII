using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviso : MonoBehaviour
{
    SpriteRenderer sr;
    float t;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        t += Time.deltaTime * 8;
        float a = Mathf.Abs(Mathf.Sin(t));
        sr.color = new Color(1, 1, 1, a);
    }
}
