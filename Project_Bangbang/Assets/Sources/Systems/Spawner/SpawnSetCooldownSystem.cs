using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SpawnSetCooldownSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _spawns;

    public SpawnSetCooldownSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _spawns = _game.GetGroup(GameMatcher.SpawnSetID);
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.SpawnSetID.Removed());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return _spawns.count == 0;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_game.hasSpawner)
            {
                _game.spawnerEntity.ReplaceCooldown(_game.spawner.set[_game.spawnSet.currID].cooldown);
            }
        }
    }
}