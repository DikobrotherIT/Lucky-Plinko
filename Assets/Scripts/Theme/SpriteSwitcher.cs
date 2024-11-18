using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour, ISwitchable
{
    public Sprite lightSprite;
    public Sprite darkSprite;
   public Image image;


    public void SwitchToLightTheme()
    {
        image.sprite = lightSprite;
    }

    public void SwitchToDarkTheme()
    {
        image.sprite = darkSprite;
    }
}
