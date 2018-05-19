using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PlayReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public PlayReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputTouchData));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return _game.gameState.active == GameState.READY &&
            entity.inputTouchData.delta != Vector2.zero;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            _meta.entityService.current.Get("spawner");
            _game.ReplaceGameState(GameState.PLAY);
        }
    }
}