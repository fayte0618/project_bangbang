using Entitas;

public interface IView
{
    string Name { get; }
    void Link (Contexts contexts, GameEntity entity, IEntityTemplate template);
}

