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

        startTile.ChangeState(TileState.Empty);
    }
}
