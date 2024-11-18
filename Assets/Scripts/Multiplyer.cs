using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Multiplyer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _text;
    private float _multiplyer;

    public Action<float> BallDroped;

    public void SetMultiplyer(Color color, float value)
    {
        _multiplyer = value;
        _text.text = _multiplyer + "x";
        _spriteRenderer.color = color;
    }

    public float GetMultiplyer()
    {
        return _multiplyer; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            ball.Freeze();
            BallDroped?.Invoke(_multiplyer);
        }
    }
}
