using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreState : GameState
{
    private float _timer;
    private int _score;

    public GameScoreState(GameManager gameManager, int score) : base(gameManager)
    {
        _score = score;
    }

    public override void Enter()
    {
        _timer = 1f;

        GameManager.BonusScore(_score);
    }

    public override void Exit()
    {
        GameManager.UpdateScoreText();
    }

    public override void Updatelogic()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        } else
        {
            if (GameManager.GridManager.IsGameOver())
            {
                GameManager.ChangeState(new GameOverState(GameManager));
            } else
            {
                GameManager.ChangeState(new GamePlayState(GameManager));
            }
        }
    }
}
