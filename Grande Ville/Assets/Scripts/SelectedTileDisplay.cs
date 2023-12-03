using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTileDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private TileData _selectedTile;
    private TileSlot _slot;

    public TileData SelectedTile { get { return _selectedTile; } }
    public TileSlot Slot { get { return _slot; } }

    public void SetTile(TileData tile, TileSlot slot)
    {
        _selectedTile = tile;
        _slot = slot;
        spriteRenderer.sprite = tile.sprite;
        spriteRenderer.gameObject.SetActive(true);
    }

    public void PutBackTile()
    {
        RemoveTile();
        _slot.PutBackTile();
    }

    public void PlayTile()
    {
        RemoveTile();
        _slot.RemoveTile();
    }

    private void RemoveTile()
    {
        _selectedTile = null;
        spriteRenderer.sprite = null;
        spriteRenderer.gameObject.SetActive(false);
    }

    public void UpdateLogic()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}