using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] private string nomeDaCenaDoJogo = "flappy"; 
    [SerializeField] private string nomeDaCenaDeSkins = "SkinsScene"; 

    /// <summary>
    /// </summary>
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDaCenaDoJogo);
    }

    /// <summary>
    /// </summary>
    public void AbrirSkins()
    {
        SceneManager.LoadScene(nomeDaCenaDeSkins);
    }

    /// <summary>
    /// </summary>
    public void SairDoJogo()
    {
        Debug.Log("Pedido para Sair do Jogo!");
        Application.Quit();
    }
}