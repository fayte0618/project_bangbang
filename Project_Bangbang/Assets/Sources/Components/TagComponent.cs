using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input]
public sealed class TagComponent : IComponent
{
    public EntityType current;
}