//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PowerupActivatedComponent powerupActivated { get { return (PowerupActivatedComponent)GetComponent(GameComponentsLookup.PowerupActivated); } }
    public bool hasPowerupActivated { get { return HasComponent(GameComponentsLookup.PowerupActivated); } }

    public void AddPowerupActivated(int newTargetEntityID, int newSelfEntityID) {
        var index = GameComponentsLookup.PowerupActivated;
        var component = CreateComponent<PowerupActivatedComponent>(index);
        component.targetEntityID = newTargetEntityID;
        component.selfEntityID = newSelfEntityID;
        AddComponent(index, component);
    }

    public void ReplacePowerupActivated(int newTargetEntityID, int newSelfEntityID) {
        var index = GameComponentsLookup.PowerupActivated;
        var component = CreateComponent<PowerupActivatedComponent>(index);
        component.targetEntityID = newTargetEntityID;
        component.selfEntityID = newSelfEntityID;
        ReplaceComponent(index, component);
    }

    public void RemovePowerupActivated() {
        RemoveComponent(GameComponentsLookup.PowerupActivated);
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

    static Entitas.IMatcher<GameEntity> _matcherPowerupActivated;

    public static Entitas.IMatcher<GameEntity> PowerupActivated {
        get {
            if (_matcherPowerupActivated == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PowerupActivated);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPowerupActivated = matcher;
            }

            return _matcherPowerupActivated;
        }
    }
}