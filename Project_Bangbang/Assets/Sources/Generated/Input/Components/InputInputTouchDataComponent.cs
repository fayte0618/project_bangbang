//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity inputTouchDataEntity { get { return GetGroup(InputMatcher.InputTouchData).GetSingleEntity(); } }
    public InputTouchDataComponent inputTouchData { get { return inputTouchDataEntity.inputTouchData; } }
    public bool hasInputTouchData { get { return inputTouchDataEntity != null; } }

    public InputEntity SetInputTouchData(UnityEngine.Vector2 newDirection, UnityEngine.Vector2 newDelta) {
        if (hasInputTouchData) {
            throw new Entitas.EntitasException("Could not set InputTouchData!\n" + this + " already has an entity with InputTouchDataComponent!",
                "You should check if the context already has a inputTouchDataEntity before setting it or use context.ReplaceInputTouchData().");
        }
        var entity = CreateEntity();
        entity.AddInputTouchData(newDirection, newDelta);
        return entity;
    }

    public void ReplaceInputTouchData(UnityEngine.Vector2 newDirection, UnityEngine.Vector2 newDelta) {
        var entity = inputTouchDataEntity;
        if (entity == null) {
            entity = SetInputTouchData(newDirection, newDelta);
        } else {
            entity.ReplaceInputTouchData(newDirection, newDelta);
        }
    }

    public void RemoveInputTouchData() {
        inputTouchDataEntity.Destroy();
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
public partial class InputEntity {

    public InputTouchDataComponent inputTouchData { get { return (InputTouchDataComponent)GetComponent(InputComponentsLookup.InputTouchData); } }
    public bool hasInputTouchData { get { return HasComponent(InputComponentsLookup.InputTouchData); } }

    public void AddInputTouchData(UnityEngine.Vector2 newDirection, UnityEngine.Vector2 newDelta) {
        var index = InputComponentsLookup.InputTouchData;
        var component = CreateComponent<InputTouchDataComponent>(index);
        component.direction = newDirection;
        component.delta = newDelta;
        AddComponent(index, component);
    }

    public void ReplaceInputTouchData(UnityEngine.Vector2 newDirection, UnityEngine.Vector2 newDelta) {
        var index = InputComponentsLookup.InputTouchData;
        var component = CreateComponent<InputTouchDataComponent>(index);
        component.direction = newDirection;
        component.delta = newDelta;
        ReplaceComponent(index, component);
    }

    public void RemoveInputTouchData() {
        RemoveComponent(InputComponentsLookup.InputTouchData);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputTouchData;

    public static Entitas.IMatcher<InputEntity> InputTouchData {
        get {
            if (_matcherInputTouchData == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputTouchData);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputTouchData = matcher;
            }

            return _matcherInputTouchData;
        }
    }
}
