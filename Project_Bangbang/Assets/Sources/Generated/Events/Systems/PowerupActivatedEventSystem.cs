//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class PowerupActivatedEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public PowerupActivatedEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.PowerupActivated)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasPowerupActivated && entity.hasPowerupActivatedListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.powerupActivated;
            foreach (var listener in e.powerupActivatedListener.value) {
                listener.OnPowerupActivated(e, component.targetEntityID, component.selfEntityID);
            }
        }
    }
}
