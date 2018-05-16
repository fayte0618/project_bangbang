using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class GunSlotsComponent : IComponent
{
    //slot number + id
    public Dictionary<int, int> current;
}