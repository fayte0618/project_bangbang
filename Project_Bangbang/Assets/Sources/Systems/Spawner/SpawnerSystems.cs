using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SpawnerSystems : Feature
{
    public SpawnerSystems (Contexts contexts) : base("Spawn Systems")
    {
        //Add(system here);
        Add(new SpawnSetCooldownSystem(contexts));
        Add(new SpawnSystem(contexts));
    }
}