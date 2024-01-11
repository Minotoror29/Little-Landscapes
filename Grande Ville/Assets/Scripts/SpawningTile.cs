using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawningTile : MonoBehaviour
{
    private TilemapManager _tilemapManager;
    private TileBase _tile;
    private Vector3Int _coordinates;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float spawningTime;
    private float _timer;

    private EventInstance _plopSound;

    public void Initialize(TilemapManager tilemapManager, TileBase tile, Sprite sprite, Vector3Int coordinates)
    {
        _tilemapManager = tilemapManager;
        _tile = tile;
        _coordinates = coordinates;

        spriteRenderer.sprite = sprite;

        _timer = spawningTime;

        _plopSound = RuntimeManager.CreateInstance("event:/Plop");
        _plopSound.start();
    }

    private void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        } else
        {
            _tilemapManager.TileMap.SetTile(_coordinates, _tile);
            Destroy(gameObject);
        }
    }
}
