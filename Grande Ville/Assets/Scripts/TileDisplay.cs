using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TileState { Inactive, Empty, Occupied, Ocean }

public class TileDisplay : MonoBehaviour, ISelectable
{
    private GameManager _gameManager;

    [SerializeField] private TileState currentState;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private Sprite emptySprite;

    private Vector2Int _coordinates;
    private List<TileDisplay> _neighbours;

    [SerializeField] private TileData tile;

    [SerializeField] private Animator animator;

    public TileData Tile { get { return tile; } }

    public Vector2Int Coordinates { get { return _coordinates; } }

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;

        SetCoordinates();
        if (tile == null)
        {
            ChangeState(TileState.Inactive);
        }
    }

    public void ChangeState(TileState nextState)
    {
        if (currentState == TileState.Ocean || currentState == TileState.Occupied) return;

        if (nextState == TileState.Empty)
        {
            if (currentState == TileState.Inactive)
            {
                currentState = nextState;
            }
        } else
        {
            currentState = nextState;
        }

        if (currentState == TileState.Inactive)
        {
            spriteRenderer.sprite = inactiveSprite;
        } else if (currentState == TileState.Empty)
        {
            spriteRenderer.sprite = emptySprite;
        }

        animator.CrossFade("TileDisplay_Spawn", 0f);
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
            if (currentState == TileState.Empty)
            {
                tile = selectedTile.SelectedTile;
                spriteRenderer.sprite = tile.sprite;
                ChangeState(TileState.Occupied);

                foreach (TileDisplay neighbour in _neighbours)
                {
                    neighbour.ChangeState(TileState.Empty);

                    foreach (Interaction interaction in this.tile.interactions)
                    {
                        if (neighbour.Tile == interaction.tile)
                        {
                            _gameManager.GainPoints(interaction.score, neighbour);
                            break;
                        }
                    }
                }

                selectedTile.PlayTile();
            }
        }
    }
}
