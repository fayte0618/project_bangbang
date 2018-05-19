﻿using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerShipTemplate : UnityEntityTemplate
{
    [SerializeField]
    private float _speed;
    [Header("Gun Settings")]
    [SerializeField]
    private int health;
    [SerializeField]
    private string[] gunEntity;
    [SerializeField]
    private string[] bulletType;
    [SerializeField]
    private EntityType tag;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddPosition(Vector3.zero);
        gameety.AddSpeed(_speed);
        gameety.isMoveFromTouch = true;

        var slots = new Dictionary<int, int>();
        for (int i = 0; i < gunEntity.Length; i++)
        {
            IEntity entity;
            contexts.meta.entityService.current.Get(gunEntity[i], out entity);
            var gun = (GameEntity)entity;
            if (bulletType.Length >= i + 1) { gun.ReplaceBullet(bulletType[i]); }
            slots.Add(i, gun.iD.number);

            gun.AddTag(tag);
        }

        gameety.AddGunSlots(slots);
        gameety.AddCollision(new Dictionary<int, CollisionType>());

        gameety.AddHealth(health);
        gameety.AddTag(tag);

        return gameety;
    }
}

