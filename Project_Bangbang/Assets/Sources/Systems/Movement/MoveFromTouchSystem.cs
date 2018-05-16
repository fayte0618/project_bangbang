using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MoveFromTouchSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _moveables;

    public MoveFromTouchSystem (Contexts contexts) : base(contexts.input)
    {
        _moveables = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position));
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.InputTouchData);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasInputTouchData;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            foreach (var move in _moveables)
            {
                move.ReplacePosition((Vector2)move.position.current + e.inputTouchData.delta);
            }
        }
    }
}