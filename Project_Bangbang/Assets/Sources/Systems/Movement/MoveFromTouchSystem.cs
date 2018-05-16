using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MoveFromTouchSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _moveables;
    private readonly MetaContext _meta;

    public MoveFromTouchSystem (Contexts contexts) : base(contexts.input)
    {
        _meta = contexts.meta;
        _moveables = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Speed, GameMatcher.MoveFromTouch));
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
                var movement = (e.inputTouchData.delta * move.speed.current) * _meta.timeService.current.Delta;
                var newPos = ((Vector2)move.position.current + movement);
                newPos = _meta.screenService.current.ConstrainToNearest(newPos);
                move.ReplacePosition(newPos);
            }
        }
    }
}