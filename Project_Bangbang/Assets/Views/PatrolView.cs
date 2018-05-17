using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class PatrolView : UnityView, IPathListener
{
    private Sequence _active;

    [SerializeField]
    private Ease _ease;

    [SerializeField]
    private int _loopCount;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private DG.Tweening.LoopType type;

    public void OnPath (GameEntity entity, PointData[] points)
    {
        if (entity.hasPath)
        {
            _active = SetAnimation(entity);
            _active.Play();
        }
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        if (entity.hasPath)
        {
            _active = SetAnimation(entity);
            _active.Play();
        }
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddPathListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemovePathListener(this);
    }

    void OnEnable ()
    {
        if (_active != null) { _active.Kill(); }
    }

    private void OnDisable ()
    {
        if (_active != null) { _active.Kill(); }
    }

    private Sequence SetAnimation (GameEntity entity)
    {
        Sequence animation;
        animation = DOTween.Sequence();
        animation.SetEase(_ease)
                  .SetLoops(_loopCount, type)
                  .SetRecyclable(true);

        foreach (var point in entity.path.points)
        {
            var move = _target.DOMove(point.position, point.duration);
            var rot = _target.DORotate(point.rotation, point.duration);
            animation.Append(move).Join(rot);
        }

        animation.
            OnUpdate(() =>
            {
                var inputety = this.contexts.input.CreateEntity();
                inputety.AddInputNewPosition(this.ID, _target.position);
            });

        return animation;
    }
}