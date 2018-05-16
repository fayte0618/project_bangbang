//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GunComponent gun { get { return (GunComponent)GetComponent(GameComponentsLookup.Gun); } }
    public bool hasGun { get { return HasComponent(GameComponentsLookup.Gun); } }

    public void AddGun(float newFireRate) {
        var index = GameComponentsLookup.Gun;
        var component = CreateComponent<GunComponent>(index);
        component.fireRate = newFireRate;
        AddComponent(index, component);
    }

    public void ReplaceGun(float newFireRate) {
        var index = GameComponentsLookup.Gun;
        var component = CreateComponent<GunComponent>(index);
        component.fireRate = newFireRate;
        ReplaceComponent(index, component);
    }

    public void RemoveGun() {
        RemoveComponent(GameComponentsLookup.Gun);
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

    static Entitas.IMatcher<GameEntity> _matcherGun;

    public static Entitas.IMatcher<GameEntity> Gun {
        get {
            if (_matcherGun == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Gun);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGun = matcher;
            }

            return _matcherGun;
        }
    }
}
