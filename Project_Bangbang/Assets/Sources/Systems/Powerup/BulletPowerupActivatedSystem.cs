using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class BulletPowerupActivatedSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public BulletPowerupActivatedSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.BulletPowerup, GameMatcher.PowerupActivated));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasBulletPowerup && entity.hasPowerupActivated;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.powerupActivated.targetEntityID);

            if (target != null && target.hasGunSlots)
            {
                if (target.hasBulletPowerup && target.bulletPowerup.srcEntityID > -1)
                {
                    var deactivate = _game.GetEntityWithID(target.bulletPowerup.srcEntityID);
                    if (deactivate != null) { deactivate.ReplaceToDestroy(1); }
                }

                target.ReplaceBulletPowerup(e.bulletPowerup.bulletEntity, e.bulletPowerup.gunsToAffect, e.iD.number);
            }
        }
    }
}