using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TileState { Inactive, Empty, Occupied }

public class TileDisplay : MonoBehaviour, ISelectable
{
    private TileState _currentState;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private Sprite emptySprite;

    private Vector2Int _coordinates;
    private List<TileDisplay> _neighbours;

    private TileData _tile;

    public Vector2Int Coordinates { get { return _coordinates; } }

    public void Initialize()
    {
        SetCoordinates();
        ChangeState(TileState.Inactive);
    }

    public void ChangeState(TileState nextState)
    {
        _currentState = nextState;

        if (_currentState == TileState.Inactive)
        {
            spriteRenderer.sprite = inactiveSprite;
        } else if (_currentState == TileState.Empty)
        {
            spriteRenderer.sprite = emptySprite;
        }
    }

    private void SetCoordinates()
    {
        _coordinates.x = (int)transform.position.x + 3;
        _coordinates.y = (int)transform.position.y + 3;
    }

    public void SetNeighbours(List<TileDisplay> tiles)
    {
        _neighbours = new();
        foreach (TileDisplay tile in tiles)
        {
            if (tile.Coordinates.x == _coordinates.x)
            {
                if (tile.Coordinates.y == _coordinates.y + 1 || tile.Coordinates.y == _coordinates.y - 1)
                {
                    _neighbours.Add(tile);
                }
            } else if (tile.Coordinates.y == _coordinates.y)
            {
                if (tile.Coordinates.x == _coordinates.x + 1 || tile.Coordinates.x == _coordinates.x - 1)
                {
                    _neighbours.Add(tile);
                }
            }

            if (_neighbours.Count == 4) break;
        }
    }

    public void OnSelect(SelectedTileDisplay selectedTile)
    {
        if (selectedTile.SelectedTile)
        {
            if (_currentState == TileState.Empty)
            {
                _tile = selectedTile.SelectedTile;
                spriteRenderer.sprite = _tile.sprite;
                _currentState = TileState.Occupied;

                selectedTile.PlayTile();
            }
        }
    }
}
