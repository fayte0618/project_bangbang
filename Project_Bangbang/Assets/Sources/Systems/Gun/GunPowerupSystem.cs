using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GunPowerupSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public GunPowerupSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.BulletPowerup.AddedOrRemoved());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGunSlots;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.hasBulletPowerup)
            {
                //add bullet override to guns
                for (int i = 0; i < e.gunSlots.current.Count; i++)
                {
                    if (i < e.bulletPowerup.gunsToAffect)
                    {
                        var gun = _game.GetEntityWithID(e.gunSlots.current[i]);
                        gun?.ReplaceBulletOverride(e.bulletPowerup.bulletEntity);
                    }
                }
            }
            else
            {
                //remove all bullet override
                for (int i = 0; i < e.gunSlots.current.Count; i++)
                {
                    var gun = _game.GetEntityWithID(e.gunSlots.current[i]);
                    if (gun != null && gun.hasBulletOverride) { gun.RemoveBulletOverride(); };
                }
            }
        }
    }
}