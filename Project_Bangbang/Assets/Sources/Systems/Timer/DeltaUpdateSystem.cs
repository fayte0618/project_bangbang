using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DeltaUpdateSystem : IExecuteSystem, IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public DeltaUpdateSystem (Contexts contexts)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Execute ()
    {
        foreach (var ety in _game.GetEntities())
        {
            ety.ReplaceDelta(_meta.timeService.current.Delta);
        }
    }

    public void Initialize ()
    {
        _game.OnEntityCreated += _game_OnEntityCreated;
    }

    private void _game_OnEntityCreated (IContext context, IEntity entity)
    {
        ((GameEntity)entity).ReplaceDelta(_meta.timeService.current.Delta);
    }
}