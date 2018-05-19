using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ResetReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public ResetReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.gameState.active == GameState.RESET;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            // do stuff to the matched entities
            var players = _game.GetEntitiesWithTag(EntityType.PLAYER);
            players.ForEach(obj => obj.ReplaceToDestroy(0));

            var enemies = _game.GetEntitiesWithTag(EntityType.ENEMY);
            enemies.ForEach(obj => obj.ReplaceToDestroy(0));

            var powerups = _game.GetEntitiesWithTag(EntityType.POWERUP);
            powerups.ForEach(obj => obj.ReplaceToDestroy(0));

            //var score = _game.GetEntitiesWithName("score");
            //score.ForEach(obj => obj.ReplaceToDestroy(0));

            var gameover = _game.GetEntitiesWithName("gameover");
            gameover.ForEach(obj => obj.ReplaceToDestroy(0));

            var spawner = _game.GetEntitiesWithName("spawner");
            spawner.ForEach(obj => obj.ReplaceToDestroy(0));

            _game.ReplaceGameState(GameState.READY);
        }
    }
}