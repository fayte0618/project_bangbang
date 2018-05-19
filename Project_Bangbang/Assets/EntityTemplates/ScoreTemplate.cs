using UnityEngine;
using System.Collections;
using Entitas;

public class ScoreTemplate : UnityEntityTemplate
{
    [SerializeField]
    private int initScore = 0;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        contexts.game.ReplaceScore(0);
        return contexts.game.scoreEntity;
    }

}
