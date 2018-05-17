using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TimerStateChangeSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _timers;

    public TimerStateChangeSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _timers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.TimerState));
    }

    public void Execute ()
    {
        foreach (var e in _timers)
        {
            switch (e.timerState.active)
            {
                case TimerState.PLAY:
                    e.ReplaceTimer(e.timer.current + _meta.timeService.current.Delta);
                    break;
                case TimerState.PAUSE:
                    //do nothing;
                    break;
                case TimerState.RESTART:
                    e.ReplaceTimer(0f);
                    break;
                default:
                    //do nothing
                    break;
            }
        }
    }
}