using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ScoreOnDamageSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;

    public ScoreOnDamageSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.InputTotalDamage);
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

            if (target != null && target.hasTag && target.tag.current == EntityType.ENEMY)
            {
                if (_game.hasScore) { _game.ReplaceScore(_game.score.current + e.inputTotalDamage.amount); }
            }
        }
    }
}