using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputCollisionSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public InputCollisionSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputCollision));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasInputCollision;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var input = e.inputCollision;
            var target = _game.GetEntityWithID(input.targetID);

            if (target != null && target.hasCollision)
            {
                var collisions = target.collision.current;

                if (collisions.ContainsKey(input.otherEntityID))
                {
                    collisions[input.otherEntityID] = input.value;
                }
                else
                {
                    collisions.Add(input.otherEntityID, input.value);
                }

                target.ReplaceCollision(collisions);
            }
        }
    }
}