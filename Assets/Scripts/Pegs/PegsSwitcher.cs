using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegsSwitcher : MonoBehaviour
{
    [SerializeField] private List<Sprite> _types;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private List<SpriteRenderer> _pegs;

    private void Awake()
    {
        PegsService.Changed += OnPegsChanged;
        OnPegsChanged();
    }

    private void OnPegsChanged()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        foreach (var item in _pegs)
        {
            item.sprite = _types[settings.CurrentPegsType];
            item.color = _colors[settings.CurrentPegsColor];
        }
    }

}
