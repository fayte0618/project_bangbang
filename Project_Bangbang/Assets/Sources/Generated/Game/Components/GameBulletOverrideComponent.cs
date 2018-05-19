//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BulletOverrideComponent bulletOverride { get { return (BulletOverrideComponent)GetComponent(GameComponentsLookup.BulletOverride); } }
    public bool hasBulletOverride { get { return HasComponent(GameComponentsLookup.BulletOverride); } }

    public void AddBulletOverride(string newEntityID) {
        var index = GameComponentsLookup.BulletOverride;
        var component = CreateComponent<BulletOverrideComponent>(index);
        component.entityID = newEntityID;
        AddComponent(index, component);
    }

    public void ReplaceBulletOverride(string newEntityID) {
        var index = GameComponentsLookup.BulletOverride;
        var component = CreateComponent<BulletOverrideComponent>(index);
        component.entityID = newEntityID;
        ReplaceComponent(index, component);
    }

    public void RemoveBulletOverride() {
        RemoveComponent(GameComponentsLookup.BulletOverride);
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

    static Entitas.IMatcher<GameEntity> _matcherBulletOverride;

    public static Entitas.IMatcher<GameEntity> BulletOverride {
        get {
            if (_matcherBulletOverride == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BulletOverride);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBulletOverride = matcher;
            }

            return _matcherBulletOverride;
        }
    }
}