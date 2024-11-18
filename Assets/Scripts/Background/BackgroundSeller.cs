using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSeller : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _locker;
    [SerializeField] private GameObject _selector;

    public Action<int> Unlocked;
    public Action<int> Selected;
    

    public void Lock()
    {
        _button.onClick.RemoveAllListeners();
        _selector.SetActive(false);
        _locker.SetActive(true);
        _button.onClick.AddListener(OnUnlockClick);
    }

    public void Unlock()
    {
        _button.onClick.RemoveAllListeners();
        _selector.SetActive(false);
        _locker.SetActive(false);
        _button.onClick.AddListener(OnSelectClick);
    }

    public void SetSelection(bool active)
    {
        _selector.SetActive(active);
    }

    public void OnSelectClick()
    {
        Selected?.Invoke(_id);
    }

    public void OnUnlockClick()
    {
        Unlocked?.Invoke(_id);
    }
}
