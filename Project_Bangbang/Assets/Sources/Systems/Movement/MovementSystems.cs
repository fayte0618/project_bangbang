﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MovementSystems : Feature
{
    public MovementSystems (Contexts contexts) : base("Movement Systems")
    {
        //Add(system here);
        Add(new InputNewPositionSystem(contexts));
        Add(new MoveFromTouchSystem(contexts));
        Add(new AutoMoveSystem(contexts));
    }
}