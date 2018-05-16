using UnityEngine;
using System.Collections;

public class UnityTimeService : MonoBehaviour, ITimeService
{
    public float Delta
    {
        get {
            return Time.deltaTime;
        }
    }

    public float UnscaledDelta
    {
        get {
            return Time.unscaledDeltaTime;
        }
    }

    public float FixedDelta
    {
        get {
            return Time.fixedDeltaTime;
        }
    }

    public float FixedUnscaledDelta
    {
        get {
            return Time.fixedUnscaledDeltaTime;
        }
    }
}
