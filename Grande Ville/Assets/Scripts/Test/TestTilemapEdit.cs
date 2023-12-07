using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTilemapEdit : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase emptyTile;

    private void Start()
    {
        tilemap.SetTile(new Vector3Int(3, 3), null);
    }
}
