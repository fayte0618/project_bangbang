using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TimeServiceInitSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private ITimeService _service;

    public TimeServiceInitSystem (Contexts contexts, ITimeService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        _meta.SetTimeService(_service);
    }
}