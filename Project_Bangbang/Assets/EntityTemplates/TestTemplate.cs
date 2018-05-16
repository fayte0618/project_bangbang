using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TestTemplate : UnityEntityTemplate
{
    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();
        gameety.AddPosition(Vector3.zero);
        return gameety;
    }
}

