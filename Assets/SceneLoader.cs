using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void LoadMenuSkins()
    {
        SceneManager.LoadScene("MenuSkin");
    }

    public void LoadJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo!");
    }
}
