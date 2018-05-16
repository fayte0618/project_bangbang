using System;
using UnityEngine;

public interface IInputService
{
    Vector2 Direction { get; }
    Vector2 Delta { get; }
}

