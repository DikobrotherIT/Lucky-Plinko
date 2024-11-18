using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoField : MonoBehaviour
{
    [SerializeField] private List<Multiplyer> _multiplyers;
    [Header("Multiplyer Values")]
    [SerializeField] private List<float> _lowRiskValue;
    [SerializeField] private List<float> _mediumRiskValue;
    [SerializeField] private List<float> _highRiskValue;
    [Header("Multiplyer Colors")]
    [SerializeField] private List<Color> _riskColor;
    public Action<float> RoundEnded;

    private void Awake()
    {
        foreach (var item in _multiplyers)
        {
            item.BallDroped += OnBallDropped;
        }
    }

    public void SetField(int riskIndex)
    {
        switch (riskIndex)
        {
            case 0:
                {
                    for (int i = 0; i < _multiplyers.Count; i++)
                    {
                        _multiplyers[i].SetMultiplyer(_riskColor[i], _lowRiskValue[i]);
                    }
                    break;
                }
            case 1:
                {
                    for (int i = 0; i < _multiplyers.Count; i++)
                    {
                        _multiplyers[i].SetMultiplyer(_riskColor[i], _mediumRiskValue[i]);
                    }
                    break;
                }
            case 2:
                {
                    for (int i = 0; i < _multiplyers.Count; i++)
                    {
                        _multiplyers[i].SetMultiplyer(_riskColor[i], _highRiskValue[i]);
                    }
                    break;
                }
        }
    }

    public void OnBallDropped(float value)
    {
        Debug.Log("Multiplyer value = " + value);
        RoundEnded?.Invoke(value);
    }
}
