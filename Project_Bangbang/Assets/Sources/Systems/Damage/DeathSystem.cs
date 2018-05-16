using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DeathSystem : ReactiveSystem<GameEntity>
{
    public DeathSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasHealth &&
            entity.health.current == 0 &&
            entity.isDead == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDead = true;
            e.AddToDestroy(1);
        }
    }
}