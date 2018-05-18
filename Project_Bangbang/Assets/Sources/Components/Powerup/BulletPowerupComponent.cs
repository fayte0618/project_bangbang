using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class BulletPowerupComponent : IComponent
{
    public string bulletEntity;
    public int gunsToAffect;
    public int srcEntityID;
}