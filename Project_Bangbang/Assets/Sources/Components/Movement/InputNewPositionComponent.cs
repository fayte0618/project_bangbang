using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Input]
public sealed class InputNewPositionComponent : IComponent
{
    public int targetID;
    public Vector3 newValue;
}