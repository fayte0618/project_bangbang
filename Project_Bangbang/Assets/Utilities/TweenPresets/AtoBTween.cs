using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class AtoBTween : MonoBehaviour, IMyTween
{
    [SerializeField]
    Transform _target;
    [SerializeField]
    Transform _origin;
    [SerializeField]
    Transform _destination;
    [SerializeField]
    float delay;
    [SerializeField]
    Ease _ease;
    [SerializeField]
    float _duration;
    [SerializeField]
    int _loopCount;
    [SerializeField]
    DG.Tweening.LoopType type;

    private Sequence _animation;

    public void Pause ()
    {
        if (_animation == null) { return; }
        _animation.Pause();
    }

    public void Play ()
    {
        Initialize();
        _animation.Play();
    }

    public void Restart ()
    {
        Initialize();
        _animation.Restart();
        _animation.Play();
    }

    void Initialize ()
    {
        if (_animation != null) { return; }
        _animation = DOTween.Sequence();

        var toOrigin = _target.DOMove(_origin.position, _duration);
        var originPause = _target.DOMove(_origin.position, delay);
        var toDestination = _target.DOMove(_destination.position, _duration);
        var destPause = _target.DOMove(_destination.position, delay);

        _animation.Append(toOrigin)
                  .Append(originPause)
                  .Append(toDestination)
                  .Append(destPause)
                  .SetEase(_ease)
                  .SetLoops(_loopCount, type);
    }
}

