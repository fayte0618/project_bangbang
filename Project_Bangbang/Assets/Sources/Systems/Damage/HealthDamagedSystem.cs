using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class HealthDamagedSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public HealthDamagedSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputTotalDamage));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasInputTotalDamage;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.inputTotalDamage.targetID);

            if (target != null && target.hasHealth)
            {
                target.ReplaceHealth(target.health.current - e.inputTotalDamage.amount);
            }
        }
    }
}