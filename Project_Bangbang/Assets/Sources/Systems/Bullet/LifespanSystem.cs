using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class LifespanSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _lifespan;
    private List<GameEntity> _buffer = new List<GameEntity>();

    public LifespanSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _lifespan = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Lifespan));
    }

    public void Execute ()
    {
        foreach (var e in _lifespan.GetEntities(_buffer))
        {
            e.ReplaceLifespan(e.lifespan.remaining - _meta.timeService.current.Delta);

            if (e.lifespan.remaining <= 0)
            {
                e.AddToDestroy(0);
            }
        }
    }
}