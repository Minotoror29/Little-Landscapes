using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private List<TileDisplay> tiles;
    [SerializeField] private TileDisplay startTile;

    [SerializeField] private TilemapManager tilemapManager;

    private int _emptyTiles;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;

        foreach (TileDisplay tile in tiles)
        {
            tile.Initialize(_gameManager, this, tilemapManager);
        }

        foreach (TileDisplay tile in tiles)
        {
            tile.SetNeighbours(tiles);
        }

        startTile.ChangeState(TileState.Empty);

        _emptyTiles = 49;
    }

    public void PlayTile()
    {
        _emptyTiles--;

        if (_emptyTiles == 0)
        {
            _gameManager.GameOver();
        }
    }
}
