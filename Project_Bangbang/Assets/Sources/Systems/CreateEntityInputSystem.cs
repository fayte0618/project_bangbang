using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CreateEntityInputSystem : ReactiveSystem<InputEntity>
{
    private readonly MetaContext _meta;
    private readonly InputContext _input;

    public CreateEntityInputSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _meta = contexts.meta;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.CreateEntity));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasCreateEntity;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            _meta.entityService.current.Get(e.createEntity.name);
        }
    }
}