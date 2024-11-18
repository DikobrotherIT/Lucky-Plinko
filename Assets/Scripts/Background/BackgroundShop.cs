using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundShop : MonoBehaviour
{
    [SerializeField] private List<BackgroundSeller> _sellers;
    [SerializeField] private GameObject _buyCanvas;
    [SerializeField] private Image _backImage;
    [SerializeField] private List<Sprite> _sprites;
    private int _currentIndex = 0;

    private void Awake()
    {
        foreach (var item in _sellers)
        {
            item.Selected += OnSelect;
            item.Unlocked += OnUnlock;
        }

        UpdateItems();
    }

    public void UpdateItems()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        foreach (var item in _sellers)
        {
            item.SetSelection(false);
        }
        for (int i = 0; i < _sellers.Count; i++)
        {
            if (settings.UnlockedBackgrounds[i])
            {
                _sellers[i].Unlock();
            }
            else
            {
                _sellers[i].Lock();
            }
        }
        _sellers[settings.CurrentBackground].SetSelection(true);
    }

    public void OnSelect(int index)
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        settings.CurrentBackground = index;
        SaveSystem.SaveData(settings);
        BackgroundService.ChangeBackground();
        UpdateItems();
    }

    public void OnUnlock(int index)
    {
        _currentIndex = index;
        _backImage.sprite = _sprites[_currentIndex];
        _buyCanvas.SetActive(true);
    }

    public void PurchaseClick()
    {
        if (Wallet.CanRemoveMoney(500))
        {
            Wallet.RemoveMoney(500);
            var settings = SaveSystem.LoadData<SettingSaveData>();
            settings.UnlockedBackgrounds[_currentIndex] = true;
            SaveSystem.SaveData(settings);
            UpdateItems();
        }
    }



}
