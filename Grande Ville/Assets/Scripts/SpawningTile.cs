using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawningTile : MonoBehaviour
{
    private TilemapManager _tilemapManager;
    private TileData _tileData;
    private Vector3Int _coordinates;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float spawningTime;
    private float _timer;

    public void Initialize(TilemapManager tilemapManager, TileData tileData, Vector3Int coordinates)
    {
        _tilemapManager = tilemapManager;
        _tileData = tileData;
        _coordinates = coordinates;

        spriteRenderer.sprite = tileData.ruleTile.m_DefaultSprite;

        _timer = spawningTime;
    }

    private void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        } else
        {
            _tilemapManager.SetOccupiedTile(_coordinates, _tileData.ruleTile);
            Destroy(gameObject);
        }
    }
}
