using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Event(true)]
public sealed class ToDestroyComponent : IComponent
{
    public uint delay;
}