using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    private SFXManager _sfxManager;

    private Image _image;
    [SerializeField] private Sprite unmutedSprite;
    [SerializeField] private Sprite mutedSprite;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _sfxManager = SFXManager.Instance;

        _image = GetComponent<Image>();

        SetSprite();
    }

    public void MuteSFX()
    {
        _sfxManager.MuteSFX();
        SetSprite();
    }

    private void SetSprite()
    {
        if (_sfxManager.Muted)
        {
            _image.sprite = mutedSprite;
        }
        else
        {
            _image.sprite = unmutedSprite;
        }
    }
}
