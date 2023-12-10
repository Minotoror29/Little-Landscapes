using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    [SerializeField] private List<TileData> tilesData;

    [SerializeField] private GameObject slotsDisplay;
    [SerializeField] private List<TileSlot> slots;
    private int _emptySlots;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private Canvas worldSpaceCanvas;
    private int _score;

    [SerializeField] private Canvas gameOverCanvas;

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

    public void GainPoints(int amount, TileDisplay tile)
    {
        _score += amount;
        scoreText.text = _score.ToString();

        ScoreDisplay newScore = Instantiate(scoreDisplay, new Vector2(tile.Coordinates.x - 3, tile.Coordinates.y - 3), Quaternion.identity, worldSpaceCanvas.transform);
        newScore.Initialize(amount);
        Destroy(newScore.gameObject, 1f);
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        slotsDisplay.gameObject.SetActive(false);
    }
}
