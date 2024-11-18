using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingSaveData : SaveData
{
    public List<bool> UnlockedBackgrounds { get; set; }
    public int CurrentBackground { get; set; }

    public List<bool> UnlockedPegsTypes { get; set; }
    public int CurrentPegsType { get; set; }

    public List<bool> UnlockedPegsColors { get; set; }
    public int CurrentPegsColor { get; set; }

    public bool DarkTheme { get; set; }

    public bool IsMusic { get; set; }

    public SettingSaveData (List<bool> isFavorite, int back, List<bool> types, int type, List<bool> colors, int color, bool theme, bool isMusic)
    {
        UnlockedBackgrounds = isFavorite;
        CurrentBackground = back;
        UnlockedPegsTypes = types;
        CurrentPegsType = type;
        UnlockedPegsColors = colors;
        CurrentPegsColor = color;
        DarkTheme = theme;
        IsMusic = isMusic;
    }
}
