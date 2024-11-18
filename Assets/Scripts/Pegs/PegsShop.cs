using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegsShop : MonoBehaviour
{
    [SerializeField] private List<BackgroundSeller> _typeSellers;
    [SerializeField] private List<BackgroundSeller> _colorSellers;
    [SerializeField] private GameObject _buyTypeCanvas;
    [SerializeField] private GameObject _buyColorCanvas;
    [SerializeField] private Image _typeImage;
    [SerializeField] private Image _colorImage;
    [SerializeField] private List<Sprite> _typeSprites;
    [SerializeField] private List<Sprite> _colorSprites;
    private int _currentIndex = 0;

    private void Awake()
    {
        foreach (var item in _typeSellers)
        {
            item.Selected += OnSelectType;
            item.Unlocked += OnUnlockType;
        }

        foreach (var item in _colorSellers)
        {
            item.Selected += OnSelectColor;
            item.Unlocked += OnUnlockColor;
        }

        UpdateItems();
    }

    public void UpdateItems()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        foreach (var item in _typeSellers)
        {
            item.SetSelection(false);
        }
        for (int i = 0; i < _typeSellers.Count; i++)
        {
            if (settings.UnlockedPegsTypes[i])
            {
                _typeSellers[i].Unlock();
            }
            else
            {
                _typeSellers[i].Lock();
            }
        }
        _typeSellers[settings.CurrentPegsType].SetSelection(true);


        foreach (var item in _colorSellers)
        {
            item.SetSelection(false);
        }
        for (int i = 0; i < _colorSellers.Count; i++)
        {
            if (settings.UnlockedPegsColors[i])
            {
                _colorSellers[i].Unlock();
            }
            else
            {
                _colorSellers[i].Lock();
            }
        }
        _colorSellers[settings.CurrentPegsColor].SetSelection(true);
    }

    public void OnSelectType(int index)
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        settings.CurrentPegsType = index;
        SaveSystem.SaveData(settings);
        PegsService.ChangePegs();
        UpdateItems();
    }

    public void OnSelectColor(int index)
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        settings.CurrentPegsColor = index;
        SaveSystem.SaveData(settings);
        PegsService.ChangePegs();
        UpdateItems();
    }



    public void OnUnlockType(int index)
    {
        _currentIndex = index;
        _typeImage.sprite = _typeSprites[_currentIndex];
        _buyTypeCanvas.SetActive(true);
    }

    public void OnUnlockColor(int index)
    {
        _currentIndex = index;
        _colorImage.sprite = _colorSprites[_currentIndex];
        _buyColorCanvas.SetActive(true);
    }

    public void PurchaseTypeClick()
    {
        if (Wallet.CanRemoveMoney(200))
        {
            Wallet.RemoveMoney(200);
            var settings = SaveSystem.LoadData<SettingSaveData>();
            settings.UnlockedPegsTypes[_currentIndex] = true;
            SaveSystem.SaveData(settings);
            UpdateItems();
        }
    }

    public void PurchaseColorClick()
    {
        if (Wallet.CanRemoveMoney(200))
        {
            Wallet.RemoveMoney(200);
            var settings = SaveSystem.LoadData<SettingSaveData>();
            settings.UnlockedPegsColors[_currentIndex] = true;
            SaveSystem.SaveData(settings);
            UpdateItems();
        }
    }
}
