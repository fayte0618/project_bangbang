using UnityEngine;
using System.Collections;
using Entitas;

public class EnemyView : UnityView, IHealthListener, IPositionListener
{
    [SerializeField]
    private TextMesh _health;
    [SerializeField]
    private int layerValue;
    [SerializeField]
    Transform[] gunSlots;

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

    public void OnHealth (GameEntity entity, int current)
    {
        _health.text = current.ToString();
    }

    public void OnPosition (GameEntity entity, Vector3 current)
    {
        if (this.transform.position != current) { this.transform.position = current; }

    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        _health.text = entity.health.current.ToString();
        _health.GetComponent<MeshRenderer>().sortingOrder = layerValue;
        this.transform.position = entity.position.current;
        if (entity.hasViewData && entity.viewData.spawnPositionID.Length > 0)
        {
            var inputety = this.contexts.input.CreateEntity();
            inputety.AddInputNewPosition(this.ID, ScenePositionUtility.Instance.GetSpawnPosition(entity.viewData.spawnPositionID));
        }
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddHealthListener(this);
        entity.AddPositionListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemoveHealthListener(this);
        entity.RemovePositionListener(this);
    }
}
