using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(true)]
public sealed class PowerupActivatedComponent : IComponent
{
    public int targetEntityID;
    public int selfEntityID;
}