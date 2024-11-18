using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Image _image;

    private void Awake()
    {
        BackgroundService.Changed += OnBackgroundChanged;
        OnBackgroundChanged();
    }

    private void OnBackgroundChanged()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        _image.sprite = _sprites[settings.CurrentBackground];
    }
}
