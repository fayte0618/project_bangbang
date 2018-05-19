using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class PowerupActivateSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public PowerupActivateSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Collision, GameMatcher.Tag,
                                        GameMatcher.PowerupDuration).AnyOf(GameMatcher.BulletPowerup));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCollision &&
            entity.collision.current.Count > 0 &&
            entity.hasTag && entity.hasPowerupDuration &&
            entity.hasPowerupActivated == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = e.collision.current
                .Where(col => (col.Value == CollisionType.ENTER || col.Value == CollisionType.STAY))
                .Select(col => _game.GetEntityWithID(col.Key))
                .FirstOrDefault(other => other.hasTag && other.tag.current == EntityType.PLAYER);

            if (target != null)
            {
                e.AddPowerupActivated(target.iD.number, e.iD.number);
                e.AddCooldown(e.powerupDuration.length);
            }
        }
    }
}