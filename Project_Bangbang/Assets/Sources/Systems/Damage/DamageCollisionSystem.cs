using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageCollisionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public DamageCollisionSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Collision, GameMatcher.Health));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCollision && entity.hasHealth;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var newHealth = e.collision.current
                            .Where(col => col.Value == CollisionType.ENTER || col.Value == CollisionType.STAY)
                            .Select(col => _game.GetEntityWithID(col.Key))
                            .Where(other =>
                            {
                                if (e.hasTag && other.hasTag) { return other.hasDamage && e.tag.current != other.tag.current; }
                                else { return other.hasDamage; }
                            })
                            .Select(other => other.damage.value)
                            .Aggregate(e.health.current, (health, damage) =>
                            {
                                return (int)Mathf.Clamp(health - damage, 0, Mathf.Infinity);
                            });

            e.ReplaceHealth(newHealth);
        }
    }
}