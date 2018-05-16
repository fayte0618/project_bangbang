using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DestroySystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _toDestroy;

    private List<GameEntity> _buffer = new List<GameEntity>();

    public DestroySystem (Contexts contexts)
    {
        _toDestroy = contexts.game.GetGroup(GameMatcher.Destroy);
    }

    public void Cleanup ()
    {
        foreach (var dty in _toDestroy.GetEntities(_buffer))
        {
            if (dty.destroy.delay > 0) { dty.ReplaceDestroy(dty.destroy.delay - 1); }
            else { dty.Destroy(); }
        }
    }
}