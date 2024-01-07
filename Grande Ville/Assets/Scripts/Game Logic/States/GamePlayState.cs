using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    public GamePlayState(GameManager gameManager) : base(gameManager)
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
        GameManager.SelectionManager.UpdateLogic();
    }
}
