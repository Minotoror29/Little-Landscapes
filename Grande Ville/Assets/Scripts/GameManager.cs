using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    [SerializeField] private List<TileData> tilesData;

    [SerializeField] private List<TileSlot> slots;
    private int _emptySlots;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        gridManager.Initialize(this);

        foreach (TileSlot slot in slots)
        {
            slot.Initialize(this);
        }

        FillSlots();

        _score = 0;
        scoreText.text = _score.ToString();
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

    public void GainPoints(int amount)
    {
        _score += amount;
        scoreText.text = _score.ToString();
    }
}
