using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GunRemoveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public GunRemoveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.GunSlots, GameMatcher.ToDestroy));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGunSlots && entity.hasToDestroy;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            foreach (var gun in e.gunSlots.current)
            {
                var ety = _game.GetEntityWithID(gun.Value);
                if (ety != null)
                {
                    ety.ReplaceToDestroy(1);
                }
            }
        }
    }
}