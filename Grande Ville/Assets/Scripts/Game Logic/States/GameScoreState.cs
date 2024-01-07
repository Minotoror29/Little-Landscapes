using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreState : GameState
{
    private float _timer;

    public GameScoreState(GameManager gameManager) : base(gameManager)
    {
    }

    public override void Enter()
    {
        _timer = 1f;
    }

    public override void Exit()
    {
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
