using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PowerupSystems : Feature
{
    public PowerupSystems (Contexts contexts) : base("Powerup Systems")
    {
        //Add(system here);
        Add(new PowerupActivateSystem(contexts));
        Add(new PowerupDeactivateSystem(contexts));
        Add(new BulletPowerupActivatedSystem(contexts));
        Add(new BulletPowerupDeactivateSystem(contexts));
    }
}