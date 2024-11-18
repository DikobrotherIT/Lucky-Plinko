using UnityEngine;
using TMPro; 

public class TextSwitcher : MonoBehaviour, ISwitchable
{
    public Color lightColor = Color.black;
    public Color darkColor = Color.white;

    public TMP_Text text; 


    public void SwitchToLightTheme()
    {
        text.color = lightColor;
    }

    public void SwitchToDarkTheme()
    {
        text.color = darkColor;
    }
}
