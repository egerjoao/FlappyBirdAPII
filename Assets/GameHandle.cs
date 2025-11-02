using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandle : MonoBehaviour
{
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private float tempoSpawn = 3f;
    
    [Header("Configuração da Posição")]
    [SerializeField] private float alturaMin = -2f; 
    [SerializeField] private float alturaMax = 2f; 

    [Header("Configuração da Dificuldade (Abertura)")]
    [SerializeField] private float aberturaInicial = 5f; 
    [SerializeField] private float aberturaMinima = 2.5f; 
    [SerializeField] private float tempoParaAberturaMinima = 60f; 

    [Header("Configuração de UI")]
    [SerializeField] private GameObject telaGameOverUI;

    private float tempoAtualSpawn = 0f;

    void Update()
    {
        if (telaGameOverUI != null && telaGameOverUI.activeInHierarchy)
        {
            return;
        }

        TrySpawn();
    }

    private void TrySpawn()
    {
        tempoAtualSpawn -= Time.deltaTime;
        if (tempoAtualSpawn > 0) return;

        float tempoDecorrido = Time.timeSinceLevelLoad; 
        float tempoNormalizado = Mathf.Clamp01(tempoDecorrido / tempoParaAberturaMinima);
        float aberturaAtual = Mathf.Lerp(aberturaInicial, aberturaMinima, tempoNormalizado);
        float alturaAleatoria = Random.Range(alturaMin, alturaMax);
        
        Vector3 posicaoSpawn = new Vector3(8, alturaAleatoria, 0);

        GameObject novoCanoObj = Instantiate(canoPrefab, posicaoSpawn, Quaternion.identity);
        
        ConfiguracaoCano config = novoCanoObj.GetComponent<ConfiguracaoCano>();
        if (config != null)
        {
            config.DefinirAbertura(aberturaAtual);
        }
        
        tempoAtualSpawn = tempoSpawn;
    }

    /// <summary>
    /// </summary>
    public void GameOver()
    {
        if (telaGameOverUI != null)
        {
            telaGameOverUI.SetActive(true);
        }

        Time.timeScale = 0f; 
    }

    /// <summary>
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}