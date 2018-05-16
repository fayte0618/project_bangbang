using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class BulletSystems : Feature
{
    public BulletSystems (Contexts contexts) : base("Bullet Systems")
    {
        //Add(system here);
        Add(new LifespanSystem(contexts));
        Add(new OnCollisionBulletDestroySystem(contexts));
    }
}