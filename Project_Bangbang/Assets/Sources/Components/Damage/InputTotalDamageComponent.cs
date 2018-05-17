using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Input]
public sealed class InputTotalDamageComponent : IComponent
{
    public int targetID;
    public int amount;
}