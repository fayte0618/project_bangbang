﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class ViewDataComponent : IComponent
{
    public string spawnPositionID;
    public string parentID;
}