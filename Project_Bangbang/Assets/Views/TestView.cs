using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TestView : UnityView, IPositionListener
{
    public void OnPosition (GameEntity entity, Vector3 current)
    {
        this.transform.position = current;
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        //do nothing
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        //do nothing
        entity.AddPositionListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        //do nothing
        entity.RemovePositionListener(this);
    }
}

