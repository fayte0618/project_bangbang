using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PowerupDeactivateSystem : ReactiveSystem<GameEntity>
{
    public PowerupDeactivateSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.PowerupActivated, GameMatcher.Cooldown));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasPowerupActivated &&
            entity.hasCooldown && entity.cooldown.current <= 0f &&
            entity.hasToDestroy == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceToDestroy(1);
        }
    }
}