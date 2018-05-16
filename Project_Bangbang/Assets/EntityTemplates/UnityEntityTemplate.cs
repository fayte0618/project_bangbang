using UnityEngine;
using System.Collections;
using Entitas;

public abstract class UnityEntityTemplate : MonoBehaviour, IEntityTemplate
{
    [SerializeField]
    string _entityName;

    public string Name { get { return _entityName; } }

    public IEntity Create ()
    {
        var entity = InitializeEntity(Contexts.sharedInstance);
        if (entity is GameEntity) { InitializeView((GameEntity)entity, Contexts.sharedInstance); }
        return entity;
    }

    protected abstract IEntity InitializeEntity (Contexts contexts);


    void InitializeView (GameEntity entity, Contexts contexts)
    {
        var views = this.gameObject.GetComponentsInChildren<IView>(true);

        if (views != null)
        {
            string[] current = new string[views.Length];
            for (int i = 0; i < views.Length; i++)
            {
                var currView = views[i];
                currView.Link(contexts, entity, this);
                current[i] = currView.Name;
            }

            entity.AddView(current);
        }
        else
        {
            UnityEntityService.Instance.Return(this);
        }
    }
}
