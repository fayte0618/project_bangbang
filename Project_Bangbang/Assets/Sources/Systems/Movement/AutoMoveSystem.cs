using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AutoMoveSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _movers;

    public AutoMoveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Speed, GameMatcher.AutoMove));
    }

    public void Execute ()
    {
        //calculate movement
        foreach (var move in _movers)
        {
            Vector2 vel = Vector2.zero;

            if (move.hasMovementPath && move.hasCurveTimer)
            {
                //calculate velocity on animation curve
                var currentX = move.movementPath.currentX;
                var currCurveMultX = currentX.Evaluate(move.curveTimer.current);

                var currentY = move.movementPath.currentY;
                var currCurveMultY = currentY.Evaluate(move.curveTimer.current);

                vel = new Vector2(currCurveMultX, currCurveMultY) * move.speed.current;
                vel *= _meta.timeService.current.Delta;
            }
            else if (move.hasDirection) { vel = (move.direction.current * move.speed.current) * _meta.timeService.current.Delta; }

            move.ReplacePosition((Vector2)move.position.current + vel);
        }
    }

    WrapMode GetCurveMode (LoopType type)
    {
        switch (type)
        {
            case LoopType.NONE:
                return WrapMode.Once;
            case LoopType.INCREMENT:
                return WrapMode.ClampForever;
            case LoopType.RESTART:
                return WrapMode.Loop;
            case LoopType.YOYO:
                return WrapMode.PingPong;
            default:
                return WrapMode.Once;
        }
    }
}