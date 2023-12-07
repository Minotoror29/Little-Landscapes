using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileSlot : MonoBehaviour, ISelectable
{
    private GameManager _gameManager;

    private TileData _tile;

    [SerializeField] private Image image;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void SetTile(TileData tile)
    {
        _tile = tile;
        image.sprite = tile.ruleTile.m_DefaultSprite;
        image.gameObject.SetActive(true);
    }

    public void OnSelect(SelectedTileDisplay selectedTile)
    {
        if (_tile == null) return;

        if (selectedTile.SelectedTile == null)
        {
            selectedTile.SetTile(_tile, this);
            image.gameObject.SetActive(false);
        } else
        {
            if (selectedTile.Slot == this)
            {
                selectedTile.PutBackTile();
            } else
            {
                selectedTile.PutBackTile();
                selectedTile.SetTile(_tile, this);
                image.gameObject.SetActive(false);
            }
        }
    }

    public void PutBackTile()
    {
        image.gameObject.SetActive(true);
    }

    public void EmptySlot()
    {
        _tile = null;
        image.sprite = null;

        _gameManager.EmptySlot();
    }
}
