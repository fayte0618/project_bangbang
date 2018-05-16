using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputNewPositionSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public InputNewPositionSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputNewPosition));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasInputNewPosition;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.inputNewPosition.targetID);

            if (target != null)
            {
                target.ReplacePosition(e.inputNewPosition.newValue);
            }
        }
    }
}