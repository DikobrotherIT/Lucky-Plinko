using System;
using UnityEngine;

[Serializable]
public class MoneySaveData : SaveData
{
    public int Money { get; set; }

    public MoneySaveData(int money)
    {
        Money = money;
    }
}
