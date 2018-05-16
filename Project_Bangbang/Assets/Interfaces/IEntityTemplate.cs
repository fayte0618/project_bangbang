using Entitas;

public interface IEntityTemplate
{
    string Name { get; }
    IEntity Create ();
}

