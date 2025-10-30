using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private float tempoSpawn = 3f;
    private float tempoAtualSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        tempoAtualSpawn-=Time.deltaTime;
        if (tempoAtualSpawn > 0) return;
        
        var novoCano = Instantiate(canoPrefab);
        novoCano.transform.position = new Vector3(8, 0, 0);
        tempoAtualSpawn = tempoSpawn;
    }
}
