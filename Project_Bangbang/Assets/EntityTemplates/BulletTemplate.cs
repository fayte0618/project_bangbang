using UnityEngine;
using System.Collections;
using Entitas;

public class BulletTemplate : UnityEntityTemplate
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Vector2 direction = Vector2.zero;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float lifespan;

    public Vector2 initPos;


    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var ety = contexts.game.CreateEntity();
        ety.AddSpeed(speed);
        ety.AddDirection(direction);
        ety.isAutoMove = true;
        ety.AddPosition(initPos);
        ety.AddLifespan(lifespan);
        ety.AddDamage(damage);
        ety.AddBullet(this.Name);

        return ety;
    }
}
