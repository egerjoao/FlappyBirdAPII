using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private float tempoSpawn = 3f;
    
    [SerializeField] private float alturaMin = -2f;
    [SerializeField] private float alturaMax = 2f;

    private float tempoAtualSpawn = 0f;

    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        tempoAtualSpawn -= Time.deltaTime;
        if (tempoAtualSpawn > 0) return;

        float alturaAleatoria = Random.Range(alturaMin, alturaMax);
        Vector3 posicaoSpawn = new Vector3(8, alturaAleatoria, 0);

        var novoCano = Instantiate(canoPrefab, posicaoSpawn, Quaternion.identity);
        
        tempoAtualSpawn = tempoSpawn;
    }
}