using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SpawnSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public SpawnSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Spawner, GameMatcher.Cooldown));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCooldown &&
            entity.cooldown.current <= 0f &&
            entity.hasSpawner;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.RemoveCooldown();
            int newID;
            if (e.spawner.repeat) { newID = (e.spawnSet.currID + 1) % e.spawner.set.Length; }
            else { newID = e.spawnSet.currID + 1; }

            if (newID == e.spawner.set.Length) { continue; }

            e.ReplaceSpawnSet(newID);
            var set = e.spawner.set[newID];

            foreach (var id in set.ids)
            {
                IEntity entity = null;
                if (_meta.entityService.current.Get(id, out entity))
                {
                    ((GameEntity)entity).AddSpawnSetID(newID);
                }
            }
        }
    }
}