using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;

    [SerializeField] private List<TileSlot> slots;
    private int _emptySlots;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (TileSlot slot in slots)
        {
            slot.Initialize(this);
        }

        FillSlots();
    }

    private void FillSlots()
    {
        foreach (TileSlot slot in slots)
        {
            slot.SetTile(GetRandomTile());
        }

        _emptySlots = 0;
    }

    private TileData GetRandomTile()
    {
        int randomIndex = Random.Range(0, tilesData.Count);
        return tilesData[randomIndex];
    }

    public void EmptySlot()
    {
        _emptySlots++;

        if (_emptySlots == slots.Count)
        {
            FillSlots();
        }
    }
}
