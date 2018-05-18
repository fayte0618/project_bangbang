using UnityEngine;
using System.Collections;
using Entitas;

public class BulletPowerupTemplate : UnityEntityTemplate
{
    [SerializeField]
    string _bulletEntityID;
    [SerializeField]
    int _gunSlots;
    [SerializeField]
    float _duration;
    [SerializeField]
    EntityType _compatibleEntity;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();

        gameety.AddBulletPowerup(_bulletEntityID, _gunSlots, -1);
        gameety.AddPowerupDuration(_duration);
        gameety.AddTag(_compatibleEntity);
        gameety.AddCollision(new System.Collections.Generic.Dictionary<int, CollisionType>());

        return gameety;
    }
}
