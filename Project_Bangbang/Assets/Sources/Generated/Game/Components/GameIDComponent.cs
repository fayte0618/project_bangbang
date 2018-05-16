//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public IDComponent iD { get { return (IDComponent)GetComponent(GameComponentsLookup.ID); } }
    public bool hasID { get { return HasComponent(GameComponentsLookup.ID); } }

    public void AddID(int newNumber) {
        var index = GameComponentsLookup.ID;
        var component = CreateComponent<IDComponent>(index);
        component.number = newNumber;
        AddComponent(index, component);
    }

    public void ReplaceID(int newNumber) {
        var index = GameComponentsLookup.ID;
        var component = CreateComponent<IDComponent>(index);
        component.number = newNumber;
        ReplaceComponent(index, component);
    }

    public void RemoveID() {
        RemoveComponent(GameComponentsLookup.ID);
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

    static Entitas.IMatcher<GameEntity> _matcherID;

    public static Entitas.IMatcher<GameEntity> ID {
        get {
            if (_matcherID == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ID);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherID = matcher;
            }

            return _matcherID;
        }
    }
}
