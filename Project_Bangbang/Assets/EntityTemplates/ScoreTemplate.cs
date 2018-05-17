using UnityEngine;
using System.Collections;
using Entitas;

public class ScoreTemplate : UnityEntityTemplate
{
    [SerializeField]
    private int initScore = 0;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        if (contexts.game.hasScore == false)
        {
            var gameety = contexts.game.CreateEntity();
            gameety.AddScore(0);
            return gameety;
        }
        return null;
    }

}
