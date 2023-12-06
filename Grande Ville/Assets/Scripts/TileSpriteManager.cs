using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private TileDisplay _tile;

    public void Initialize(TileDisplay tile)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tile = tile;
    }

    public void CheckNeighbours(List<TileDisplay> neighbours)
    {

        List<TileDisplay> sameNeighbours = new();
        foreach (TileDisplay neighbour in neighbours)
        {
            if (neighbour.Tile == _tile.Tile)
            {
                sameNeighbours.Add(neighbour);
            }
        }

        if (sameNeighbours.Count == 0)
        {
            _spriteRenderer.sprite = _tile.Tile.baseSprite;
            return;
        }

        Debug.Log(_tile.Coordinates.x + "," + _tile.Coordinates.y + " Check neighbours");

        bool top = false;
        bool bottom = false;
        bool left = false;
        bool right = false;

        foreach (TileDisplay neighbour in sameNeighbours)
        {
            if (neighbour.Coordinates.x == _tile.Coordinates.x)
            {
                if (neighbour.Coordinates.y == _tile.Coordinates.y + 1)
                {
                    top = true;
                } else if (neighbour.Coordinates.y == _tile.Coordinates.y - 1)
                {
                    bottom = true;
                }
            } else if (neighbour.Coordinates.y == _tile.Coordinates.y)
            {
                if (neighbour.Coordinates.x == _tile.Coordinates.x + 1)
                {
                    right = true;
                }
                else if (neighbour.Coordinates.x == _tile.Coordinates.x - 1)
                {
                    left = true;
                }
            }
        }

        if (right && bottom && !left && !top)
        {
            _spriteRenderer.sprite = _tile.Tile.squareTopLeftSprite;
        } else if (left && right && bottom && !top)
        {
            _spriteRenderer.sprite = _tile.Tile.squareTopSprite;
        } else if (left && bottom && !top && !right)
        {
            _spriteRenderer.sprite = _tile.Tile.squareTopRightSprite;
        } else if (top && bottom && right && !left)
        {
            _spriteRenderer.sprite = _tile.Tile.squareLeftSprite;
        } else if (top && bottom && left && right)
        {
            _spriteRenderer.sprite = _tile.Tile.squareMiddleSprite;
        } else if (top && bottom && left && !right)
        {
            _spriteRenderer.sprite = _tile.Tile.squareRightSprite;
        } else if (top && right && !bottom && !left)
        {
            _spriteRenderer.sprite = _tile.Tile.squareBottomLeftSprite;
        } else if (top && left && right && !bottom)
        {
            _spriteRenderer.sprite = _tile.Tile.squareBottomSprite;
        } else if (left && top && !right && !bottom)
        {
            _spriteRenderer.sprite = _tile.Tile.squareBottomRightSprite;
        } else if (right && !left && !top && !bottom)
        {
            _spriteRenderer.sprite = _tile.Tile.hLineLeftSprite;
        } else if (right && left && !top && !bottom)
        {
            _spriteRenderer.sprite = _tile.Tile.hLineMiddleSprite;
        } else if (left && !top && !bottom && !right)
        {
            _spriteRenderer.sprite = _tile.Tile.hLineRightSprite;
        } else if (bottom && !left && !right && ! top)
        {
            _spriteRenderer.sprite = _tile.Tile.vLineTopSprite;
        } else if (top && bottom && !right && !left)
        {
            _spriteRenderer.sprite = _tile.Tile.vLineMiddleSprite;
        } else if (top && !bottom && !right && !left)
        {
            _spriteRenderer.sprite = _tile.Tile.vLineBottomSprite;
        }
    }
}
