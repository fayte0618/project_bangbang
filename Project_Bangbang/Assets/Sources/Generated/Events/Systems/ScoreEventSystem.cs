//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ScoreEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public ScoreEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Score)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasScore && entity.hasScoreListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.score;
            foreach (var listener in e.scoreListener.value) {
                listener.OnScore(e, component.current);
            }
        }
    }
}
