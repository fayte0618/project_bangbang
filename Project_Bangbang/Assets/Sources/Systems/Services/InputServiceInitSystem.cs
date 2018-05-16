using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputServiceInitSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IInputService _service;

    public InputServiceInitSystem (Contexts contexts, IInputService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetInputService(_service);
    }
}