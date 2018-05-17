using UnityEngine;
using System.Collections;
using Entitas;

public abstract class UnityEntityTemplate : MonoBehaviour, IEntityTemplate
{
    [Header("Entity Settings")]
    [SerializeField]
    string _entityName;
    [SerializeField]
    string _spawnPositionID;
    [SerializeField]
    string _parentID;

    public string Name { get { return _entityName; } }

    public IEntity Create ()
    {
        var entity = InitializeEntity(Contexts.sharedInstance);
        if (entity is GameEntity)
        {
            var gameety = (GameEntity)entity;
            gameety.AddViewData(_spawnPositionID, _parentID);
            InitializeView(gameety, Contexts.sharedInstance);
        }
        return entity;
    }

    protected abstract IEntity InitializeEntity (Contexts contexts);


    void InitializeView (GameEntity entity, Contexts contexts)
    {
        var views = this.gameObject.GetComponentsInChildren<IView>(true);

        if (views != null && views.Length > 0)
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
            Contexts.sharedInstance.meta.entityService.current.Return(this);
        }
    }
}
