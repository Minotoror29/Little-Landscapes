using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    [SerializeField] private Tile emptyTile;

    public void SetEmptyTile(Vector3Int position)
    {
        tilemap.SetTile(position, emptyTile);
    }

    public void SetOccupiedTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, tile);
    }
}
