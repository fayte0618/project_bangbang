using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityScreenService : MonoBehaviour, IScreenService
{
    [SerializeField]
    private Collider2D _bounds;


    public Vector2 ConstrainToNearest (Vector2 worldPos)
    {
        return _bounds.bounds.ClosestPoint(worldPos);
    }
}
