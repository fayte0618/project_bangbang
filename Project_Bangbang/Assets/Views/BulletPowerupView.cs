using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class BulletPowerupView : UnityView, IPowerupActivatedListener
{
    [SerializeField]
    SpriteRenderer _spriteRenderer;
    [SerializeField]
    Collider2D _detector;

    public void OnPowerupActivated (GameEntity entity, int targetEntityID, int selfEntityID)
    {
        _spriteRenderer.enabled = false;
        _detector.enabled = false;
    }

    //insert serialized fields here
    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        _spriteRenderer.enabled = true;
        _detector.enabled = true;

        if (entity.hasViewData && entity.viewData.spawnPositionID.Length > 0)
        {
            this.transform.position = ScenePositionUtility.Instance.GetSpawnPosition(entity.viewData.spawnPositionID);
        }
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddPowerupActivatedListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemovePowerupActivatedListener(this);
    }
}

