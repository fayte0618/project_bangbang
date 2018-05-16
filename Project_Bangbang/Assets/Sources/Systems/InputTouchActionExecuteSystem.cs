using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputTouchActionExecuteSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly InputContext _input;

    public InputTouchActionExecuteSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _input = contexts.input;
    }

    public void Execute ()
    {
        var input = _meta.inputService.current;
        _input.ReplaceInputTouchData(input.Direction, input.Delta);
    }
}