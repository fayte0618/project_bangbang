using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ReadyStateReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public ReadyStateReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGameState &&
            entity.gameState.active == GameState.READY;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            _meta.entityService.current.Get("player");
            _meta.entityService.current.Get("score");
            _meta.entityService.current.Get("gameover");
        }
    }
}