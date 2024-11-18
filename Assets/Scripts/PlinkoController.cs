using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlinkoController : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private List<Toggle> _riskToggles;
    [SerializeField] private List<Toggle> _rowsToggles;
    [SerializeField] private List<PlinkoField> _plinkoFields;
    [SerializeField] private BallPricer _ballPricer;
    private bool _roundStarted = false;
    private int _currentBet = 0;


    private void Awake()
    {
        _ball.SetActive(false);
        _ball.Freeze();
        foreach (var item in _riskToggles)
        {
            item.onValueChanged.AddListener(delegate { OnTogglesChanged(); });
            item.isOn = false;
        }
        _riskToggles[0].isOn = true;
        foreach (var item in _rowsToggles)
        {
            item.onValueChanged.AddListener(delegate { OnTogglesChanged(); });
            item.isOn = false;
        }
        foreach (var item in _plinkoFields)
        {
            item.RoundEnded += OnRoundEnded;
        }
        _rowsToggles[0].isOn = true;
        OnTogglesChanged();

    }

    private void OnRoundEnded(float value)
    {
        _ball.SetPosition(new Vector2(0,0));
        int win = Mathf.RoundToInt(_currentBet * value);
        Wallet.AddMoney(win);
        _currentBet = 0;
        _roundStarted = false;
        foreach (var item in _riskToggles)
        {
            item.interactable = true;
        }
        foreach (var item in _rowsToggles)
        {
            item.interactable = true;
        }
    }

    public void OnTogglesChanged()
    {
        foreach (var item in _plinkoFields)
        {
            item.gameObject.SetActive(false);
        }
        _plinkoFields[GetSelectedToggleIndex(_rowsToggles)].gameObject.SetActive(true);
        _plinkoFields[GetSelectedToggleIndex(_rowsToggles)].SetField(GetSelectedToggleIndex(_riskToggles));
        _ball.SetSprite(GetSelectedToggleIndex(_riskToggles));
    }

    public int GetSelectedToggleIndex(List<Toggle> toggles)
    {
        int index = 0;
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void DropBall()
    {
        if (Wallet.CanRemoveMoney(_ballPricer.GetCurrentBet()) && !_roundStarted)
        {
            Vector2 pos = new Vector2(GetRandomFloat(), 0);
            _ball.SetPosition(pos);
            _ball.SetActive(true);
            _ball.Unfreeze();
            _currentBet = _ballPricer.GetCurrentBet();
            Wallet.RemoveMoney(_currentBet);
            _roundStarted = true;
            foreach (var item in _riskToggles)
            {
                item.interactable = false;
            }
            foreach (var item in _rowsToggles)
            {
                item.interactable = false;
            }
        }
    }

    float GetRandomFloat()
    {
        float value;
        do
        {
            value = Random.Range(-0.25f, 0.25f);
        } while (value == 0f);

        return value;
    }
}
