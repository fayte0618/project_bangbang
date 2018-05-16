using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CollisionSystems : Feature
{
    public CollisionSystems (Contexts contexts) : base("Collision Systems")
    {
        //Add(system here);
        Add(new InputCollisionSystem(contexts));
        Add(new CollisionCleanupSystem(contexts));
    }
}