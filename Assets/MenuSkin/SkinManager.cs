using UnityEngine;
using UnityEngine.SceneManagement;


public class SkinManager : MonoBehaviour
{
    public BirdPreview birdPreview; // Referência ao preview no menu
         [SerializeField] private string nomeCenaMenuPrincipal = "MenuScene";

    // Chamado quando o jogador confirma a skin
    public void ConfirmSkin()
    {
        int selectedIndex = birdPreview.GetCurrentIndex(); // pega o índice atual
        PlayerPrefs.SetInt("SelectedSkin", selectedIndex); // salva no PlayerPrefs
        PlayerPrefs.Save();

        Debug.Log("Skin confirmada: " + selectedIndex);
    }

    public void VoltarParaMenuPrincipal()
{
    SceneManager.LoadScene("MenuScene");
}

    // Recupera o índice salvo (para o Player usar depois)
    public static int GetSavedSkin()
    {
        return PlayerPrefs.GetInt("SelectedSkin", 0); // 0 = padrão
    }
}
