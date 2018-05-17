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

    /// <summary>
    /// random world point
    /// </summary>
    /// <returns></returns>
    public Vector2 RandomPoint ()
    {
        var xPos = UnityEngine.Random.Range(_bounds.bounds.min.x, _bounds.bounds.max.x);
        var yPos = UnityEngine.Random.Range(_bounds.bounds.min.y, _bounds.bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
