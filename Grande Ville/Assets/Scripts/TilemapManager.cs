using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    [SerializeField] private Tile emptyTile;
    [SerializeField] private SpawningTile spawningTile;

    public void SetEmptyTile(Vector3Int position)
    {
        tilemap.SetTile(position, emptyTile);
    }

    public void SpawnOccupiedTile(Vector3Int position, TileData tileData)
    {
        tilemap.SetTile(position, null);
        SpawningTile newTile = Instantiate(spawningTile, position - new Vector3Int(3, 3, 0), Quaternion.identity);
        newTile.Initialize(this, tileData, position);
    }

    public void SetOccupiedTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, tile);
    }
}
