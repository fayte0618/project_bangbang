using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique]
public sealed class SpawnerComponent : IComponent
{
    public SpawnData[] set;
    public bool repeat;
}