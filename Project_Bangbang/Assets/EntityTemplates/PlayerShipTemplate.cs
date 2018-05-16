using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerShipTemplate : UnityEntityTemplate
{
    [SerializeField]
    private float _speed;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddPosition(Vector3.zero);
        gameety.AddSpeed(_speed);
        gameety.isMoveFromTouch = true;

        return gameety;
    }
}

