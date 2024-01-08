using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    [SerializeField] private Tile emptyTile;
    [SerializeField] private Tile inactiveTile;
    [SerializeField] private SpawningTile spawningTile;

    public Tilemap TileMap { get { return tilemap; } }

    public IEnumerator SpawnInactiveTiles(List<TileDisplay> tiles)
    {
        List<TileDisplay> shuffledTiles = new();
        foreach (TileDisplay tile in tiles)
        {
            shuffledTiles.Add(tile);
        }

        for (int i = shuffledTiles.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            TileDisplay temp = shuffledTiles[i];
            shuffledTiles[i] = shuffledTiles[j];
            shuffledTiles[j] = temp;
        }

        foreach (TileDisplay tile in shuffledTiles)
        {
            if (tile.Tile == null)
            {
                Vector3Int position = new(tile.Coordinates.x, tile.Coordinates.y, 0);
                SpawningTile newTile = Instantiate(spawningTile, position - new Vector3Int(3, 3, 0), Quaternion.identity);
                newTile.Initialize(this, inactiveTile, inactiveTile.sprite, position);

                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public IEnumerator SpawnEmptyTile(Vector3Int position)
    {
        yield return new WaitForSeconds(0.1f);

        tilemap.SetTile(position, null);
        SpawningTile newTile = Instantiate(spawningTile, position - new Vector3Int(3, 3, 0), Quaternion.identity);
        newTile.Initialize(this, emptyTile, emptyTile.sprite, position);
    }

    public void SpawnOccupiedTile(Vector3Int position, TileData tileData)
    {
        tilemap.SetTile(position, null);
        SpawningTile newTile = Instantiate(spawningTile, position - new Vector3Int(3, 3, 0), Quaternion.identity);
        newTile.Initialize(this, tileData.ruleTile, tileData.ruleTile.m_DefaultSprite, position);
    }
}
