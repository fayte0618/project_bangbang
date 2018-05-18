using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class JobAutoMoveSystem : JobSystem<GameEntity>
{

    public JobAutoMoveSystem (GameContext context, int threads) :
        base(context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Speed, GameMatcher.AutoMove)), threads)
    {
    }

    protected override void Execute (GameEntity entity)
    {
        Vector2 vel = Vector2.zero;

        if (entity.hasMovementPath && entity.hasCurveTimer)
        {
            //calculate velocity on animation curve
            var currentX = entity.movementPath.currentX;
            var currCurveMultX = currentX.Evaluate(entity.curveTimer.current);

            var currentY = entity.movementPath.currentY;
            var currCurveMultY = currentY.Evaluate(entity.curveTimer.current);

            vel = new Vector2(currCurveMultX, currCurveMultY) * entity.speed.current;
            vel *= entity.delta.current;
        }
        else if (entity.hasDirection) { vel = (entity.direction.current * entity.speed.current) * entity.delta.current; }

        //move.ReplacePosition((Vector2)move.position.current + vel);
        entity.position.current = (Vector2)entity.position.current + vel;
    }
}