using UnityEngine;
using System.Collections;
using Entitas;

public class EnemyView : UnityView, IHealthListener, IPositionListener
{
    [SerializeField]
    private TextMesh _health;
    [SerializeField]
    private int layerValue;

    public void OnHealth (GameEntity entity, int current)
    {
        _health.text = current.ToString();
    }

    public void OnPosition (GameEntity entity, Vector3 current)
    {
        this.transform.position = current;
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        _health.text = entity.health.current.ToString();
        _health.GetComponent<MeshRenderer>().sortingOrder = layerValue;
        this.transform.position = entity.position.current;
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
