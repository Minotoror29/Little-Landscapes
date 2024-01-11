using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager _instance;
    public static SFXManager Instance => _instance;

    private bool _muted = false;

    private Bus _bus;

    public bool Muted { get { return _muted; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _bus = RuntimeManager.GetBus("bus:/SFX Bus");
    }

    public void MuteSFX()
    {
        _muted = !_muted;

        if (_muted)
        {
            _bus.setVolume(Mathf.Pow(10.0f, -75f / 20f));
        } else
        {
            _bus.setVolume(Mathf.Pow(10.0f, 0f / 20f));
        }
    }
}
