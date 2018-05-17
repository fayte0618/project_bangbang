using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageCollisionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public DamageCollisionSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
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

            //checks and totals entity received damage from another entity with a different tag
            var totalDamage = e.collision.current
                            .Where(col => col.Value == CollisionType.ENTER || col.Value == CollisionType.STAY)
                            .Select(col => _game.GetEntityWithID(col.Key))
                            .Where(other =>
                            {
                                if (e.hasTag && other.hasTag) { return other.hasDamage && e.tag.current != other.tag.current; }
                                else { return other.hasDamage; }
                            })
                            .Select(other => other.damage.value)
                            .Aggregate(0, (total, damage) => total + damage);

            if (totalDamage > 0)
            {
                var inputety = _input.CreateEntity();
                inputety.AddInputTotalDamage(e.iD.number, totalDamage);
                inputety.ReplaceToDestroy(1);
            }
        }
    }
}