using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private MusicManager _musicManager;

    private Image _image;
    [SerializeField] private Sprite unmutedSprite;
    [SerializeField] private Sprite mutedSprite;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _musicManager = MusicManager.Instance;

        _image = GetComponent<Image>();

        SetSprite();
    }

    public void MuteMusic()
    {
        _musicManager.MuteMusic();
        SetSprite();
    }

    private void SetSprite()
    {
        if (_musicManager.Muted)
        {
            _image.sprite = mutedSprite;
        } else
        {
            _image.sprite = unmutedSprite;
        }
    }
}
