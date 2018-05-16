using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerShipTemplate : UnityEntityTemplate
{
    [SerializeField]
    private float _speed;
    [Header("Gun Settings")]
    [SerializeField]
    private string gunEntity;
    [SerializeField]
    private int numGuns = 5;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddPosition(Vector3.zero);
        gameety.AddSpeed(_speed);
        gameety.isMoveFromTouch = true;

        var slots = new Dictionary<int, int>();
        for (int i = 0; i < numGuns; i++)
        {
            IEntity entity;
            contexts.meta.entityService.current.Get(gunEntity, out entity);

            slots.Add(i, ((GameEntity)entity).iD.number);
        }

        gameety.AddGunSlots(slots);

        return gameety;
    }
}

