using UnityEngine;
using System.Collections;

public class PlayerView : UnityView, IPositionListener
{
    [SerializeField]
    private Transform[] gunSlots;

    void Update ()
    {
        if (this.entity.hasGunSlots)
        {
            foreach (var slot in this.entity.gunSlots.current)
            {
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddInputNewPosition(slot.Value, gunSlots[slot.Key].position);
            }
        }
        
    }

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
