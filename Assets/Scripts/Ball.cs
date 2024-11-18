using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _sprites;

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetSprite(int index)
    {
        _spriteRenderer.sprite = _sprites[index];
    }

    public void SetPosition(Vector2 pos)
    {
        transform.localPosition = pos;
    }

    public void Freeze()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void Unfreeze()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
    }

}
