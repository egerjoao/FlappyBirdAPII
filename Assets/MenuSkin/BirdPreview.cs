using UnityEngine;

public class BirdPreview : MonoBehaviour
{
    public Animator animator;  // Substitui o SpriteRenderer
    public RuntimeAnimatorController[] skins; // Array de animações
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
        if (animator != null && skins.Length > 0)
        {
            animator.runtimeAnimatorController = skins[currentIndex];
        }
        else
        {
            Debug.LogWarning("Animator ou skins não atribuídos!");
        }
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
