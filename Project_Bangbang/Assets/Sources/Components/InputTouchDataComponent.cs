using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Unique]
public sealed class InputTouchDataComponent : IComponent
{
    public Vector2 direction;
    public Vector2 delta;
}