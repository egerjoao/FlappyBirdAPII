using UnityEngine;

[System.Serializable]
public class BirdSkin
{
    public string skinName;
    public Sprite[] frames; // sprites animados da skin
}

public class BirdSkinSelector : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // referência ao SpriteRenderer do Player
    public BirdSkin[] skins;              // todas as skins disponíveis
    public float animationSpeed = 0.1f;   // tempo entre frames da animação

    private int currentSkin = 0;
    private int currentFrame = 0;
    private float timer = 0f;

    void Update()
    {
        // animação da skin atual
        timer += Time.deltaTime;
        if (timer >= animationSpeed)
        {
            timer = 0f;
            currentFrame++;
            if (currentFrame >= skins[currentSkin].frames.Length)
                currentFrame = 0;
            spriteRenderer.sprite = skins[currentSkin].frames[currentFrame];
        }
    }

    // trocar skin
    public void SetSkin(int skinIndex)
    {
        if (skinIndex < 0 || skinIndex >= skins.Length) return;

        currentSkin = skinIndex;
        currentFrame = 0;
        spriteRenderer.sprite = skins[currentSkin].frames[currentFrame];
    }
}
