using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class IDInitializeSystem : IInitializeSystem
{
    private readonly GameContext _game;

    public IDInitializeSystem (Contexts contexts)
    {
        _game = contexts.game;
    }

    public void Initialize ()
    {
        _game.OnEntityCreated += _game_OnEntityCreated;
    }

    private void _game_OnEntityCreated (IContext context, IEntity entity)
    {
        ((GameEntity)entity).AddID(entity.creationIndex);
    }
}