using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class SpawnSetIDComponent : IComponent
{
    public int number;
}