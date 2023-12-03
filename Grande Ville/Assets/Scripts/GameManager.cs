using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;

    [SerializeField] private List<TileSlot> slots;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (TileSlot slot in slots)
        {
            slot.SetTile(GetRandomTile());
        }
    }

    private TileData GetRandomTile()
    {
        int randomIndex = Random.Range(0, tilesData.Count);
        return tilesData[randomIndex];
    }
}
