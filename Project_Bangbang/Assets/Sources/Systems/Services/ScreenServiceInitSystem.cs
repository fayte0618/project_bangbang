using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ScreenServiceInitSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IScreenService _service;

    public ScreenServiceInitSystem (Contexts contexts, IScreenService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetScreenService(_service);
    }
}