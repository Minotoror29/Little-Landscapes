using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState _currentState;

    [SerializeField] private GridManager gridManager;
    [SerializeField] private TilemapManager tilemapManager;
    [SerializeField] private SelectionManager selectionManager;

    [SerializeField] private List<TileData> tilesData;

    [SerializeField] private GameObject slotsDisplay;
    [SerializeField] private List<TileSlot> slots;
    private int _emptySlots;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private Canvas worldSpaceCanvas;
    [SerializeField] private BonusScore bonusScorePrefab;
    [SerializeField] private Transform scoreTransform;
    private int _score;

    [SerializeField] private Canvas gameOverCanvas;

    public GridManager GridManager { get { return gridManager; } }
    public SelectionManager SelectionManager { get { return selectionManager; } }
    public BonusScore BonusScorePrefab { get { return bonusScorePrefab; } }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        StartCoroutine(gridManager.Initialize(this));

        foreach (TileSlot slot in slots)
        {
            slot.Initialize(this);
        }

        FillSlots();

        _score = 0;
        scoreText.text = _score.ToString();

        ChangeState(new GameStartState(this));
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

    public void ChangeState(GameState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();
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
        
        ScoreDisplay newScore = Instantiate(scoreDisplay, new Vector2(tile.Coordinates.x - 3, tile.Coordinates.y - 3), Quaternion.identity, worldSpaceCanvas.transform);
        newScore.Initialize(amount);
        Destroy(newScore.gameObject, 1f);
    }

    public void BonusScore(int value)
    {
        if (value == 0) return;

        BonusScore newBonusScore = Instantiate(bonusScorePrefab, scoreTransform);
        newBonusScore.Initialize(value);
        Destroy(newBonusScore.gameObject, 1f);
    }

    public void UpdateScoreText()
    {
        scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        slotsDisplay.gameObject.SetActive(false);

        tilemapManager.GameOverAnimation();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        _currentState.Updatelogic();
    }
}
