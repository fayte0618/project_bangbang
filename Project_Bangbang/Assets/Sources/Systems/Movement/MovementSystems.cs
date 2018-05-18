using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MovementSystems : Feature
{
    public MovementSystems (Contexts contexts) : base("Movement Systems")
    {
        //Add(system here);
        Add(new InputNewPositionSystem(contexts));
        Add(new MoveFromTouchSystem(contexts));
        Add(new JobAutoMoveSystem(contexts.game, 4));
        Add(new AutoMoveSystem(contexts));

        Add(new SetRandomPointsSystem(contexts));
    }
}