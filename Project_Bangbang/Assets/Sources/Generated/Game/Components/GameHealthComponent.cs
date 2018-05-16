//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HealthComponent health { get { return (HealthComponent)GetComponent(GameComponentsLookup.Health); } }
    public bool hasHealth { get { return HasComponent(GameComponentsLookup.Health); } }

    public void AddHealth(int newCurrent) {
        var index = GameComponentsLookup.Health;
        var component = CreateComponent<HealthComponent>(index);
        component.current = newCurrent;
        AddComponent(index, component);
    }

    public void ReplaceHealth(int newCurrent) {
        var index = GameComponentsLookup.Health;
        var component = CreateComponent<HealthComponent>(index);
        component.current = newCurrent;
        ReplaceComponent(index, component);
    }

    public void RemoveHealth() {
        RemoveComponent(GameComponentsLookup.Health);
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

    static Entitas.IMatcher<GameEntity> _matcherHealth;

    public static Entitas.IMatcher<GameEntity> Health {
        get {
            if (_matcherHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Health);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealth = matcher;
            }

            return _matcherHealth;
        }
    }
}