using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallPricer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _bet = 10;

    public void SetPrice()
    {
        _text.text = _bet.ToString();
    }

    public int GetCurrentBet()
    {
        return _bet;
    }

    public void UpBet()
    {
        if (_bet < 1280)
        {
            _bet *= 2;
            SetPrice();
        }
    }

    public void DownBet()
    {
        if(_bet > 10)
        {
            _bet /= 2;
            SetPrice();
        }
    }
}
