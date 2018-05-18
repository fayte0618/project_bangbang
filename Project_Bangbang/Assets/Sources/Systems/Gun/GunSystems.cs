using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GunSystems : Feature
{
    public GunSystems (Contexts contexts) : base("Gun Systems")
    {
        //Add(system here);
        Add(new GunPowerupSystem(contexts));
        Add(new AutoShootSystem(contexts));
        Add(new GunCooldownSystem(contexts));
        Add(new GunRemoveSystem(contexts));
    }
}