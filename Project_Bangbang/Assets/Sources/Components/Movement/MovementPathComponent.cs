using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class MovementPathComponent : IComponent
{
    public AnimationCurve currentX;
    public AnimationCurve currentY;
    public LoopType type;
}