﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AutoShootSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public AutoShootSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Cooldown);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCooldown &&
            entity.cooldown.current <= 0f &&
            entity.hasGun && entity.hasBullet &&
            entity.isShoot == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isShoot = true;
            _meta.entityService.current.Get(e.bullet.entityID);
            e.ReplaceCooldown(e.gun.fireRate);
        }
    }
}