using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] private string nomeDaCenaDoJogo = "flappy"; 
    [SerializeField] private string nomeDaCenaDeSkins = "MenuSkins"; 
    [SerializeField] private string nomeDaCenaPrincipal = "MenuPrincipal";

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

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(nomeDaCenaPrincipal);
    }

    /// <summary>
    /// </summary>
    public void SairDoJogo()
    {
        Debug.Log("Pedido para Sair do Jogo!");
        Application.Quit();
    }
}