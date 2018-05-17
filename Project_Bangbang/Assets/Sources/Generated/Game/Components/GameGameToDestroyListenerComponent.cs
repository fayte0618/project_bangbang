//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameToDestroyListenerComponent gameToDestroyListener { get { return (GameToDestroyListenerComponent)GetComponent(GameComponentsLookup.GameToDestroyListener); } }
    public bool hasGameToDestroyListener { get { return HasComponent(GameComponentsLookup.GameToDestroyListener); } }

    public void AddGameToDestroyListener(System.Collections.Generic.List<IGameToDestroyListener> newValue) {
        var index = GameComponentsLookup.GameToDestroyListener;
        var component = CreateComponent<GameToDestroyListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameToDestroyListener(System.Collections.Generic.List<IGameToDestroyListener> newValue) {
        var index = GameComponentsLookup.GameToDestroyListener;
        var component = CreateComponent<GameToDestroyListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameToDestroyListener() {
        RemoveComponent(GameComponentsLookup.GameToDestroyListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameToDestroyListener;

    public static Entitas.IMatcher<GameEntity> GameToDestroyListener {
        get {
            if (_matcherGameToDestroyListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameToDestroyListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameToDestroyListener = matcher;
            }

            return _matcherGameToDestroyListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGameToDestroyListener(IGameToDestroyListener value) {
        var listeners = hasGameToDestroyListener
            ? gameToDestroyListener.value
            : new System.Collections.Generic.List<IGameToDestroyListener>();
        listeners.Add(value);
        ReplaceGameToDestroyListener(listeners);
    }

    public void RemoveGameToDestroyListener(IGameToDestroyListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameToDestroyListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameToDestroyListener();
        } else {
            ReplaceGameToDestroyListener(listeners);
        }
    }
}
