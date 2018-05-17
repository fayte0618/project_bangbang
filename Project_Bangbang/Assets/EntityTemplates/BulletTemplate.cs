using UnityEngine;
using System.Collections;
using Entitas;

public class BulletTemplate : UnityEntityTemplate
{
    [SerializeField]
    private float speed = 1f;
    //[SerializeField]
    //private Vector2 direction = Vector2.zero;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float lifespan;

    public Vector2 initPos;

    [SerializeField]
    private AnimationCurve _movementPathX;
    [SerializeField]
    private AnimationCurve _movementPathY;
    [SerializeField]
    private LoopType _type;


    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var ety = contexts.game.CreateEntity();
        ety.AddSpeed(speed);
        //ety.AddDirection(direction);
        ety.isAutoMove = true;
        ety.AddPosition(initPos);
        ety.AddLifespan(lifespan);
        ety.AddDamage(damage);
        ety.AddBullet(this.Name);
        ety.AddTimerState(TimerState.PLAY);
        ety.AddMovementPath(_movementPathX, _movementPathY, _type);
        ety.AddCurveTimer(0f);

        return ety;
    }
}
