using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ScoreSystems : Feature
{
    public ScoreSystems (Contexts contexts) : base("Score Systems")
    {
        //Add(system here);
        Add(new ScoreOnDamageSystem(contexts));
    }
}