using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class EnemyTemplate : UnityEntityTemplate
{
    [SerializeField]
    private int health;
    [SerializeField]
    private Vector2 initPos;
    [SerializeField]
    private EntityType tag;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddCollision(new Dictionary<int, CollisionType>());
        gameety.AddHealth(health);
        gameety.AddPosition(initPos);
        gameety.AddTag(tag);

        return gameety;
    }

}
