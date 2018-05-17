using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class EnemyTemplate : UnityEntityTemplate
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Vector2 _initPos;
    [SerializeField]
    private EntityType _tag;
    [SerializeField]
    private string[] gunEntity;
    [SerializeField]
    private Range numPoints;
    [SerializeField]
    private Range durPerPoint;
    //[SerializeField]
    //private float _speed;
    //[SerializeField]
    //private AnimationCurve _movementPathX;
    //[SerializeField]
    //private AnimationCurve _movementPathY;
    //[SerializeField]
    //private LoopType _type;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddCollision(new Dictionary<int, CollisionType>());
        gameety.AddHealth(_health);
        gameety.AddPosition(_initPos);
        gameety.AddTag(_tag);
        gameety.AddCurveTimer(0f);
        //gameety.AddSpeed(_speed);
        //gameety.AddTimerState(TimerState.PLAY);
        //gameety.AddMovementPath(_movementPathX, _movementPathY, _type);
        //gameety.isAutoMove = true;

        var slots = new Dictionary<int, int>();
        for (int i = 0; i < gunEntity.Length; i++)
        {
            IEntity entity;
            contexts.meta.entityService.current.Get(gunEntity[i], out entity);
            var gun = (GameEntity)entity;
            slots.Add(i, gun.iD.number);

            gun.AddTag(_tag);
        }

        gameety.AddGunSlots(slots);

        gameety.AddRandomPath(numPoints, true, durPerPoint);

        return gameety;
    }

}
