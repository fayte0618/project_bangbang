using UnityEngine;
using System.Collections;
using Entitas;

public class BlankGameTemplate : UnityEntityTemplate
{
    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var gameety = contexts.game.CreateEntity();

        return gameety;
    }
}
