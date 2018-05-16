using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class CollisionComponent : IComponent
{
    public Dictionary<int, CollisionType> current;
}