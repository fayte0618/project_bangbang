using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class EntityServiceInitSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IEntityService _service;

    public EntityServiceInitSystem (Contexts contexts, IEntityService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetEntityService(_service);
    }
}