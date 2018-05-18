//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PathListenerComponent pathListener { get { return (PathListenerComponent)GetComponent(GameComponentsLookup.PathListener); } }
    public bool hasPathListener { get { return HasComponent(GameComponentsLookup.PathListener); } }

    public void AddPathListener(System.Collections.Generic.List<IPathListener> newValue) {
        var index = GameComponentsLookup.PathListener;
        var component = CreateComponent<PathListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePathListener(System.Collections.Generic.List<IPathListener> newValue) {
        var index = GameComponentsLookup.PathListener;
        var component = CreateComponent<PathListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePathListener() {
        RemoveComponent(GameComponentsLookup.PathListener);
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

    static Entitas.IMatcher<GameEntity> _matcherPathListener;

    public static Entitas.IMatcher<GameEntity> PathListener {
        get {
            if (_matcherPathListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PathListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPathListener = matcher;
            }

            return _matcherPathListener;
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

    public void AddPathListener(IPathListener value) {
        var listeners = hasPathListener
            ? pathListener.value
            : new System.Collections.Generic.List<IPathListener>();
        listeners.Add(value);
        ReplacePathListener(listeners);
    }

    public void RemovePathListener(IPathListener value, bool removeComponentWhenEmpty = true) {
        var listeners = pathListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePathListener();
        } else {
            ReplacePathListener(listeners);
        }
    }
}