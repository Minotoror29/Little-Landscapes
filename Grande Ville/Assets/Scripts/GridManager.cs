using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private List<TileDisplay> tiles;
    [SerializeField] private TileDisplay startTile;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;

        foreach (TileDisplay tile in tiles)
        {
            tile.Initialize(_gameManager);
        }

        foreach (TileDisplay tile in tiles)
        {
            tile.SetNeighbours(tiles);
        }

        startTile.ChangeState(TileState.Empty);
    }
}
