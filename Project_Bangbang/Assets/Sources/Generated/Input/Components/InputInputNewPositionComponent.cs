//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputNewPositionComponent inputNewPosition { get { return (InputNewPositionComponent)GetComponent(InputComponentsLookup.InputNewPosition); } }
    public bool hasInputNewPosition { get { return HasComponent(InputComponentsLookup.InputNewPosition); } }

    public void AddInputNewPosition(int newTargetID, UnityEngine.Vector3 newNewValue) {
        var index = InputComponentsLookup.InputNewPosition;
        var component = CreateComponent<InputNewPositionComponent>(index);
        component.targetID = newTargetID;
        component.newValue = newNewValue;
        AddComponent(index, component);
    }

    public void ReplaceInputNewPosition(int newTargetID, UnityEngine.Vector3 newNewValue) {
        var index = InputComponentsLookup.InputNewPosition;
        var component = CreateComponent<InputNewPositionComponent>(index);
        component.targetID = newTargetID;
        component.newValue = newNewValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputNewPosition() {
        RemoveComponent(InputComponentsLookup.InputNewPosition);
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

    static Entitas.IMatcher<InputEntity> _matcherInputNewPosition;

    public static Entitas.IMatcher<InputEntity> InputNewPosition {
        get {
            if (_matcherInputNewPosition == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputNewPosition);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputNewPosition = matcher;
            }

            return _matcherInputNewPosition;
        }
    }
}
