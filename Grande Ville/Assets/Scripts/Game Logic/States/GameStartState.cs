using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameState
{
    private float _timer = 2f;

    public GameStartState(GameManager gameManager) : base(gameManager)
    {
    }

    public override void Enter()
    {
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
            GameManager.ChangeState(new GamePlayState(GameManager));
        }
    }
}
