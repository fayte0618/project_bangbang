using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class BulletPowerupDeactivateSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public BulletPowerupDeactivateSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.PowerupActivated, GameMatcher.ToDestroy));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasPowerupActivated && entity.hasBulletPowerup &&
            entity.hasToDestroy;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.powerupActivated.targetEntityID);

            if (target != null &&
                target.hasBulletPowerup &&
                target.bulletPowerup.srcEntityID == e.iD.number) { target.RemoveBulletPowerup(); }
        }
    }
}