using Entitas;
using System.Collections.Generic;
using System.Linq;

public class OnCollisionBulletDestroySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public OnCollisionBulletDestroySystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCollision;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var bullets = e.collision.current
                            .Where(col => col.Value == CollisionType.ENTER || col.Value == CollisionType.STAY)
                            .Select(col => _game.GetEntityWithID(col.Key))
                            .Where(other => other.hasToDestroy == false && other.hasBullet)
                            .Where(other =>
                            {
                                if (other.hasTag && e.hasTag) { return other.tag.current != e.tag.current; }
                                else { return true; }
                            });

            foreach (var bullet in bullets)
            {
                bullet.ReplaceToDestroy(1);
            }
        }
    }
}