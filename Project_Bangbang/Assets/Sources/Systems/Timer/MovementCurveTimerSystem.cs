using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MovementCurveTimerSystem : IExecuteSystem
{

    private readonly IGroup<GameEntity> _timer;
    private MetaContext _meta;

    public MovementCurveTimerSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _timer = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.CurveTimer, GameMatcher.TimerState, GameMatcher.MovementPath));
    }

    public void Execute ()
    {
        foreach (var timer in _timer)
        {
            switch (timer.timerState.active)
            {
                case TimerState.PLAY:
                    PlayCurveTimer(timer);
                    break;
                case TimerState.PAUSE:
                    //do nothing;
                    break;
                case TimerState.RESTART:
                    timer.ReplaceCurveTimer(0f);
                    break;
                default:
                    //do nothing
                    break;
            }
        }
    }

    void PlayCurveTimer (GameEntity entity)
    {
        switch (entity.movementPath.type)
        {
            case LoopType.INCREMENT:
            {
                entity.ReplaceCurveTimer(entity.curveTimer.current + _meta.timeService.current.Delta);
                break;
            }
            case LoopType.RESTART:
            {
                var newTime = entity.curveTimer.current + _meta.timeService.current.Delta;
                newTime = Mathf.Repeat(newTime, entity.movementPath.currentX.keys[entity.movementPath.currentX.length - 1].time);
                entity.ReplaceCurveTimer(newTime);
                break;
            }
            case LoopType.YOYO:
            {
                var newTime = entity.curveTimer.current + _meta.timeService.current.Delta;
                newTime = Mathf.PingPong(newTime, entity.movementPath.currentX.keys[entity.movementPath.currentX.length - 1].time);
                entity.ReplaceCurveTimer(newTime);
                break;
            }
            case LoopType.NONE:
                break;
        }
    }
}