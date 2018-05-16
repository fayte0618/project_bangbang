using UnityEngine;
using System.Collections;

public class GunView : UnityView, IPositionListener
{
    public void OnPosition (GameEntity entity, Vector3 current)
    {
        this.transform.position = current;
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddPositionListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemovePositionListener(this);
    }
}
