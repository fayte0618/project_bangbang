using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TimerSystems : Feature
{
    public TimerSystems (Contexts contexts) : base("Timer Systems")
    {
        //Add(system here);
        Add(new TimerStateChangeSystem(contexts));
        Add(new MovementCurveTimerSystem(contexts));
        Add(new CooldownSystem(contexts));
    }
}