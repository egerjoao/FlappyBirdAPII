using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public BirdPreview birdPreview; // referência do preview
    public Player player;           // referência do Player na cena do jogo

    public void ConfirmSkin()
    {
        if (player != null && birdPreview != null)
        {
            int selectedIndex = birdPreview.GetCurrentIndex();
            player.SetSkin(selectedIndex);
        }
    }
}
