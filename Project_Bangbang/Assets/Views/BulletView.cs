using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class BulletView : UnityView, IPositionListener, IGameTagListener
{
    [SerializeField]
    SpriteRenderer _renderer;

    public void OnPosition (GameEntity entity, Vector3 current)
    {
        this.transform.position = current;
    }

    public void OnTag (GameEntity entity, EntityType current)
    {
        if (entity.hasBullet && entity.hasTag && entity.tag.current == EntityType.ENEMY)
        {
            _renderer.color = Color.red;
        }
        else
        {
            _renderer.color = Color.white;
        }
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        //do nothing
        this.SetParent();
        _renderer = GetComponentInChildren<SpriteRenderer>();

    }

    protected override void RegisterListeners (GameEntity entity)
    {
        //do nothing
        entity.AddPositionListener(this);
        entity.AddGameTagListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        //do nothing
        entity.RemovePositionListener(this);
        entity.RemoveGameTagListener(this);
    }
}

