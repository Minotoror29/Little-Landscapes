using System;
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

    [Header("Game Over")]
    [SerializeField] private List<TileDisplayList> tileRows;
    [SerializeField] private GameOverTile gameOverTile;

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
            int j = UnityEngine.Random.Range(0, i + 1);

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

    public void GameOverAnimation()
    {
        for (int i = 0; i < tileRows.Count; i++)
        {
            foreach (TileDisplay tile in tileRows[i].tiles)
            {
                Vector3Int position = new(tile.Coordinates.x, tile.Coordinates.y, 0);
                GameOverTile newTile = Instantiate(gameOverTile, position - new Vector3Int(3, 3, 0), Quaternion.identity);
                newTile.Initialize(tilemap.GetSprite(position), i * 0.1f);
            }
        }

        for (int i = 0; i < tileRows.Count; i++)
        {
            foreach (TileDisplay tile in tileRows[i].tiles)
            {
                tilemap.SetTile(new Vector3Int(tile.Coordinates.x, tile.Coordinates.y, 0), null);
            }
        }
    }

    [Serializable]
    public class TileDisplayList
    {
        public List<TileDisplay> tiles;
    }
}
