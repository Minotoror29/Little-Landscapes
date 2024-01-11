using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MusicState { Playing, FadeIn, FadeOut }

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    private EventInstance _music;

    [SerializeField] private float fadeSpeed = 0.25f;
    private MusicState _currentMusicState;
    private float _fadeTimer;

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
        Initialize();
    }

    public void Initialize()
    {
        _music = RuntimeManager.CreateInstance("event:/Music");
        _music.start();
        _currentMusicState = MusicState.Playing;

        SceneManager.activeSceneChanged += CheckScene;
    }

    private void CheckScene(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _fadeTimer = 1f;
            _currentMusicState = MusicState.FadeOut;
        } else if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            _fadeTimer = 0f;
            _currentMusicState = MusicState.FadeIn;
        }
    }

    private void Update()
    {
        if (_currentMusicState == MusicState.FadeIn)
        {
            if (_fadeTimer < 1f)
            {
                _fadeTimer += Time.deltaTime * fadeSpeed;
                _music.setParameterByName("Music Volume", _fadeTimer);
            } else
            {
                _currentMusicState = MusicState.Playing;
            }
        } else if (_currentMusicState == MusicState.FadeOut)
        {
            if (_fadeTimer > 0f)
            {
                _fadeTimer -= Time.deltaTime * fadeSpeed;
                _music.setParameterByName("Music Volume", _fadeTimer);
            } else
            {
                _currentMusicState = MusicState.Playing;
            }
        }
    }
}
