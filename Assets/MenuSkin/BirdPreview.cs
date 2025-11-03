using UnityEngine;

public class BirdPreview : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] skins;
    private int currentIndex = 0;

    void Start()
    {
        UpdatePreview();
    }

    public void NextSkin()
    {
        if (skins.Length == 0) return;
        currentIndex = (currentIndex + 1) % skins.Length;
        UpdatePreview();
    }

    public void PreviousSkin()
    {
        if (skins.Length == 0) return;
        currentIndex = (currentIndex - 1 + skins.Length) % skins.Length;
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        if (spriteRenderer != null && skins.Length > 0)
        {
            spriteRenderer.sprite = skins[currentIndex];
        }
        else
        {
            Debug.LogWarning("SpriteRenderer ou skins não atribuídos!");
        }
    }

    // 👇 ADICIONE ESTA FUNÇÃO AQUI
    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
