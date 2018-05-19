using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique, Event(false)]
public sealed class GameStateComponent : IComponent
{
    public GameState active;
}