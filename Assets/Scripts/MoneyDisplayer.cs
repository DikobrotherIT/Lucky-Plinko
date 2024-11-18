using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private void Awake()
    {
        Wallet.MoneyChanged += UpdateMoney;
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        _moneyText.text = Wallet.CurrentMoney.ToString();
    }
}
