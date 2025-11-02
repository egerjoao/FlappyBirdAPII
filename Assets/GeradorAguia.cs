using UnityEngine;

public class GeradorAguia : MonoBehaviour
{
    [Header("Prefab da Águia")]
    [SerializeField] private GameObject aguiaPrefab;

    [Header("Configurações de Spawn")]
    [SerializeField] private float tempoSpawnInicial = 5f;
    [SerializeField] private float tempoSpawnMinimo = 1.5f;
    [SerializeField] private float tempoParaDificuldadeMax = 60f; 

    [SerializeField] private float alturaMin = -2f;
    [SerializeField] private float alturaMax = 2f;

    [Header("Velocidade da Águia")]
    [SerializeField] private float velocidadeInicial = 5f;
    [SerializeField] private float velocidadeMaxima = 12f;

    [Header("Score mínimo para começar")]
    [SerializeField] private int scoreMinimo = 5;

    private float tempoAtualSpawn;

    void Update()
    {
        if (Score.instance == null || Score.instance.ScoreAtual < scoreMinimo)
            return;

        tempoAtualSpawn -= Time.deltaTime;

        if (tempoAtualSpawn <= 0f)
        {
            SpawnAguia();
            tempoAtualSpawn = GetTempoSpawnAtual();
        }
    }

    private float GetTempoSpawnAtual()
    {
        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / tempoParaDificuldadeMax);
        return Mathf.Lerp(tempoSpawnInicial, tempoSpawnMinimo, t);
    }

    private float GetVelocidadeAguiaAtual()
    {
        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / tempoParaDificuldadeMax);
        return Mathf.Lerp(velocidadeInicial, velocidadeMaxima, t);
    }

    private void SpawnAguia()
    {
        float y = Random.Range(alturaMin, alturaMax);
        Vector3 pos = new Vector3(9f, y, 0);

        GameObject novaAguia = Instantiate(aguiaPrefab, pos, Quaternion.identity);

        Aguia scriptAguia = novaAguia.GetComponent<Aguia>();
        if (scriptAguia != null)
            scriptAguia.DefinirVelocidade(GetVelocidadeAguiaAtual());
    }
}
