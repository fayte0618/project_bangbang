//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity spawnerEntity { get { return GetGroup(GameMatcher.Spawner).GetSingleEntity(); } }
    public SpawnerComponent spawner { get { return spawnerEntity.spawner; } }
    public bool hasSpawner { get { return spawnerEntity != null; } }

    public GameEntity SetSpawner(SpawnData[] newSet, bool newRepeat) {
        if (hasSpawner) {
            throw new Entitas.EntitasException("Could not set Spawner!\n" + this + " already has an entity with SpawnerComponent!",
                "You should check if the context already has a spawnerEntity before setting it or use context.ReplaceSpawner().");
        }
        var entity = CreateEntity();
        entity.AddSpawner(newSet, newRepeat);
        return entity;
    }

    public void ReplaceSpawner(SpawnData[] newSet, bool newRepeat) {
        var entity = spawnerEntity;
        if (entity == null) {
            entity = SetSpawner(newSet, newRepeat);
        } else {
            entity.ReplaceSpawner(newSet, newRepeat);
        }
    }

    public void RemoveSpawner() {
        spawnerEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpawnerComponent spawner { get { return (SpawnerComponent)GetComponent(GameComponentsLookup.Spawner); } }
    public bool hasSpawner { get { return HasComponent(GameComponentsLookup.Spawner); } }

    public void AddSpawner(SpawnData[] newSet, bool newRepeat) {
        var index = GameComponentsLookup.Spawner;
        var component = CreateComponent<SpawnerComponent>(index);
        component.set = newSet;
        component.repeat = newRepeat;
        AddComponent(index, component);
    }

    public void ReplaceSpawner(SpawnData[] newSet, bool newRepeat) {
        var index = GameComponentsLookup.Spawner;
        var component = CreateComponent<SpawnerComponent>(index);
        component.set = newSet;
        component.repeat = newRepeat;
        ReplaceComponent(index, component);
    }

    public void RemoveSpawner() {
        RemoveComponent(GameComponentsLookup.Spawner);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawner;

    public static Entitas.IMatcher<GameEntity> Spawner {
        get {
            if (_matcherSpawner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Spawner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawner = matcher;
            }

            return _matcherSpawner;
        }
    }
}