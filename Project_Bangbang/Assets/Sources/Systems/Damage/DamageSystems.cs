using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DamageSystems : Feature
{
    public DamageSystems (Contexts contexts) : base("Damage Systems")
    {
        //Add(system here);
        Add(new DamageCollisionSystem(contexts));
        Add(new HealthDamagedSystem(contexts));
        Add(new DeathSystem(contexts));

    }
}