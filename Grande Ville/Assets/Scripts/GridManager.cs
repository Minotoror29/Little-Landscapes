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

    public IEnumerator Initialize(GameManager gameManager)
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

        _emptyTiles = 49;

        StartCoroutine(tilemapManager.SpawnInactiveTiles(tiles));

        yield return new WaitForSeconds(1.25f);

        startTile.ChangeState(TileState.Empty);
    }

    public void PlayTile()
    {
        _emptyTiles--;
    }

    public bool IsGameOver()
    {
        return _emptyTiles == 0;
    }
}
