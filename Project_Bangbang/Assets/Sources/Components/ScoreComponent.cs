﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique, Event(true)]
public sealed class ScoreComponent : IComponent
{
    public int current;
}