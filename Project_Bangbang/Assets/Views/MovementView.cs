using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using DG.Tweening;

public class MovementView : UnityView
{
    [SerializeField]
    AtoBTween movement;

    private void Start ()
    {
        movement.Play();
    }

    private void Update ()
    {
        //var inputety = this.contexts.input.CreateEntity();
        //inputety.AddInputNewPosition(this.ID, this.transform.position);
    }

    //insert serialized fields here
    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        
    }
}

