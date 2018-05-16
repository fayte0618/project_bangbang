using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AutoMoveSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _movers;

    private List<GameEntity> _buffer = new List<GameEntity>();

    public AutoMoveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Direction,
                                            GameMatcher.Speed, GameMatcher.AutoMove));
    }

    public void Execute ()
    {
        //calculate movement
        foreach (var move in _movers.GetEntities(_buffer))
        {
            var moveSpd = (move.direction.current * move.speed.current) * _meta.timeService.current.Delta;
            move.ReplacePosition((Vector2)move.position.current + moveSpd);
        }
    }
}