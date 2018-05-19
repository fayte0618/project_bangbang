using UnityEngine;
using System.Collections;
using Entitas;

public class GamestateTemplate : UnityEntityTemplate
{
    [SerializeField]
    private GameState _init;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddGameState(_init);

        return gameety;
    }

}
