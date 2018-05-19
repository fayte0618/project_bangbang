using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GameOverReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public GameOverReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return _game.gameState.active == GameState.PLAY &&
            entity.hasHealth && entity.health.current <= 0 &&
            entity.hasTag && entity.tag.current == EntityType.PLAYER;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            _game.ReplaceGameState(GameState.GAMEOVER);
        }
    }
}