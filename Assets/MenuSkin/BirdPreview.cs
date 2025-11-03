using UnityEngine;
using UnityEngine.UI;

public class BirdPreview : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; // sprite que mostra a skin
    [SerializeField] private Sprite[] skins; // array de sprites das skins
    private int currentIndex = 0;

    private void Start()
    {
        if (skins.Length > 0)
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

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    private void UpdatePreview()
    {
        spriteRenderer.sprite = skins[currentIndex];
    }
}
