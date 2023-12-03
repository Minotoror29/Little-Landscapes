using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private List<TileDisplay> tiles;
    [SerializeField] private TileDisplay startTile;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (TileDisplay tile in tiles)
        {
            tile.Initialize();
        }

        foreach (TileDisplay tile in tiles)
        {
            tile.SetNeighbours(tiles);
        }

        startTile.ChangeState(TileState.Empty);
    }
}
