using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileSlot : MonoBehaviour, ISelectable
{
    private TileData _tile;

    [SerializeField] private Image image;

    public void SetTile(TileData tile)
    {
        _tile = tile;
        image.sprite = tile.sprite;
    }

    public void OnSelect()
    {
        Debug.Log("Click Slot");
    }
}
