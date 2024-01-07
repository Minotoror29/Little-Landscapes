using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public GameOverState(GameManager gameManager) : base(gameManager)
    {
    }

    public override void Enter()
    {
        GameManager.GameOver();
    }

    public override void Exit()
    {
    }

    public override void Updatelogic()
    {
    }
}