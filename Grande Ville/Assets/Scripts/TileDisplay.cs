using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TileState { Inactive, Empty, Occupied }

public class TileDisplay : MonoBehaviour
{
    private TileState _currentState;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private Sprite emptySprite;

    private Vector2Int _coordinates;

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

    private void OnMouseDown()
    {
        Debug.Log("Click");
    }
}
