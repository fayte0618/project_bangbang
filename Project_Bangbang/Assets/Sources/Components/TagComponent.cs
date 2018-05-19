using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Event(true)]
public sealed class TagComponent : IComponent
{
    [EntityIndex]
    public EntityType current;
}