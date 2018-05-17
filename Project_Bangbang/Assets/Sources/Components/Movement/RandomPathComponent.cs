using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class RandomPathComponent : IComponent
{
    public Range numPoints;
    public bool includeRotation;
    public Range duration;
}