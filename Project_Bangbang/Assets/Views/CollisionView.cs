using UnityEngine;
using System.Collections;

public class CollisionView : UnityView
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        collision.CreateInputCollision(this, CollisionType.ENTER);
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        collision.CreateInputCollision(this, CollisionType.STAY);
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        collision.CreateInputCollision(this, CollisionType.EXIT);
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {

    }

    protected override void RegisterListeners (GameEntity entity)
    {

    }

    protected override void UnregisterListeners (GameEntity entity)
    {

    }
}
