﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Meta, Unique]
public sealed class InputServiceComponent : IComponent
{
    public IInputService current;
}