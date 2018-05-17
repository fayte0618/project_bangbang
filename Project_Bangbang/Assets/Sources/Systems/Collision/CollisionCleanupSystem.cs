﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CollisionCleanupSystem : ICleanupSystem
{
    private IGroup<GameEntity> _collisions;

    public CollisionCleanupSystem (Contexts contexts)
    {
        _collisions = contexts.game.GetGroup(GameMatcher.Collision);
    }

    public void Cleanup ()
    {
        foreach (var col in _collisions)
        {
            var dict = col.collision.current;
            dict.Clear();
            col.ReplaceCollision(dict);
        }
    }
}