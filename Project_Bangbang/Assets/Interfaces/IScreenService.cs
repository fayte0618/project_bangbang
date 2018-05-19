using System;
using System.Collections.Generic;
using UnityEngine;

public interface IScreenService
{
    Vector2 ConstrainToNearest (Vector2 position);
    bool IsWithinView (Vector2 position);
    Vector2 RandomPoint ();
}
