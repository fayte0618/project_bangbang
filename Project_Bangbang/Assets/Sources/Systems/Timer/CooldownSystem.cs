using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CooldownSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _cooldown;
    private MetaContext _meta;

    public CooldownSystem (Contexts contexts)
    {
        _cooldown = contexts.game.GetGroup(GameMatcher.Cooldown);
        _meta = contexts.meta;
    }

    public void Execute ()
    {
        foreach (var cldn in _cooldown)
        {
            cldn.ReplaceCooldown(cldn.cooldown.current - _meta.timeService.current.Delta);
        }
    }
}