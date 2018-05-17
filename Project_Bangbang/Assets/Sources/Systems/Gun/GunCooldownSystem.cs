using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GunCooldownSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _guns;

    public GunCooldownSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _guns = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Gun, GameMatcher.Cooldown));
    }

    public void Execute ()
    {
        foreach (var e in _guns)
        {
            if (e.cooldown.current <= 0) { e.isShoot = false; }
        }
    }
}