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
        return _game.hasGameState &&
            _game.gameState.active == GameState.READY &&
            Mathf.Approximately(entity.inputTouchData.direction.x, 0f) == false;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log($"play state: {e.inputTouchData.direction}");
            // do stuff to the matched entities
            _meta.entityService.current.Get("spawner");
            _game.ReplaceGameState(GameState.PLAY);
        }
    }
}