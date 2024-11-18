using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private List<Image> _buttonImages;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private AudioMixer _audioMixer;
    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    private void OnEnable()
    {
        var game = SaveSystem.LoadData<SettingSaveData>();
        if (game.IsMusic)
        {
            foreach (var item in _buttonImages)
            {
                item.sprite = _sprites[0];
            }
            _audioMixer.SetFloat("MusicVolume", _maxVolume);
        }
        else
        {
            foreach (var item in _buttonImages)
            {
                item.sprite = _sprites[1];
            }
            _audioMixer.SetFloat("MusicVolume", _minVolume);
        }
    }

    public void OnChangeMusicClick()
    {
        var game = SaveSystem.LoadData<SettingSaveData>();
        if (game.IsMusic)
        {
            foreach (var item in _buttonImages)
            {
                item.sprite = _sprites[1];
            }
            game.IsMusic = false;
            _audioMixer.SetFloat("MusicVolume", _minVolume);
        }
        else
        {
            foreach (var item in _buttonImages)
            {
                item.sprite = _sprites[0];
            }
            game.IsMusic = true;
            _audioMixer.SetFloat("MusicVolume", _maxVolume);
        }
        SaveSystem.SaveData(game);
    }

}
