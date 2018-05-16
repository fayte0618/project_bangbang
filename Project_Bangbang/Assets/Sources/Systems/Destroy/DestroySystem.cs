using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DestroySystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _toDestroy;
    private InputContext _input;

    private List<GameEntity> _destroyBuffer = new List<GameEntity>();

    public DestroySystem (Contexts contexts)
    {
        _input = contexts.input;
        _toDestroy = contexts.game.GetGroup(GameMatcher.ToDestroy);
    }

    public void Cleanup ()
    {
        foreach (var dty in _toDestroy.GetEntities(_destroyBuffer))
        {
            if (dty.toDestroy.delay > 0) { dty.ReplaceToDestroy(dty.toDestroy.delay - 1); }
            else { dty.Destroy(); }
        }

        foreach (var ety in _input.GetEntities())
        {
            ety.Destroy();
        }
    }
}