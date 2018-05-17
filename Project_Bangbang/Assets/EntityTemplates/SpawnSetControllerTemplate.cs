using UnityEngine;
using System.Collections;
using Entitas;

public class SpawnSetControllerTemplate : UnityEntityTemplate
{
    [SerializeField]
    SpawnData[] _set;
    [SerializeField]
    bool _repeat;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        if (contexts.game.hasSpawner) { return null; }

        var gameety = contexts.game.CreateEntity();
        gameety.AddSpawner(_set, _repeat);
        gameety.AddSpawnSet(-1);
        gameety.AddCooldown(0f);

        return gameety;
    }
}
