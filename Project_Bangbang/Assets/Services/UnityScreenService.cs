using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityScreenService : MonoBehaviour, IScreenService
{
    [SerializeField]
    private Collider2D _bounds;
    [SerializeField]
    private Collider2D _patrolBounds;


    public Vector2 ConstrainToNearest (Vector2 worldPos)
    {
        return _bounds.bounds.ClosestPoint(worldPos);
    }

    public bool IsWithinView (Vector2 position)
    {
        return _bounds.bounds.Contains(new Vector3(position.x, position.y, _bounds.transform.position.z));
    }

    /// <summary>
    /// random world point
    /// </summary>
    /// <returns></returns>
    public Vector2 RandomPoint ()
    {
        var xPos = UnityEngine.Random.Range(_patrolBounds.bounds.min.x, _patrolBounds.bounds.max.x);
        var yPos = UnityEngine.Random.Range(_patrolBounds.bounds.min.y, _patrolBounds.bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
