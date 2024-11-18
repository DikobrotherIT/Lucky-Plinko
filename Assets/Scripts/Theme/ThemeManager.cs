using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;

public class ThemeManager : MonoBehaviour
{
    public List<ISwitchable> switchables = new List<ISwitchable>();
    public Image _buttonImage;
    public List<Sprite> _buttonSprites;

    private void Awake()
    {
        switchables.AddRange(FindObjectsOfType<MonoBehaviour>(true).OfType<ISwitchable>());
    }


    private void Start()
    {
       
        foreach (var switchable in switchables)
        {
            try
            {
                switchable.SwitchToDarkTheme();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Ошибка при вызове метода у объекта: {switchable}. Сообщение: {ex.Message}");
            }
        }
        Debug.Log("switchables count: " + switchables.Count);
        //UpdateTheme();
    }

    public void ToggleTheme()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        settings.DarkTheme = !settings.DarkTheme;
        SaveSystem.SaveData(settings);
        UpdateTheme();

    }

    private void UpdateTheme()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();

        if (settings.DarkTheme)
        {
            _buttonImage.sprite = _buttonSprites[0];
        }
        else
        {
            _buttonImage.sprite = _buttonSprites[1];
        }
        
        if (settings.DarkTheme)
        {
            foreach (var switchable in switchables)
            {
                switchable.SwitchToDarkTheme();
            }
        }
        else
        {
            foreach (var switchable in switchables)
            {
                switchable.SwitchToLightTheme();
            }
        }

    }
}
