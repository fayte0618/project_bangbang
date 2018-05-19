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
    float _lifespan;
    [SerializeField]
    EntityType _tag;
    [SerializeField]
    private Range numPoints;
    [SerializeField]
    private Range durPerPoint;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();

        gameety.AddBulletPowerup(_bulletEntityID, _gunSlots, -1);
        gameety.AddPowerupDuration(_duration);
        gameety.AddTag(_tag);
        gameety.AddCollision(new System.Collections.Generic.Dictionary<int, CollisionType>());
        gameety.AddLifespan(_lifespan);
        gameety.AddRandomPath(numPoints, false, durPerPoint);

        return gameety;
    }
}
