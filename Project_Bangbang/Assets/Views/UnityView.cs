using UnityEngine;
using System.Collections;
using Entitas.Unity;

public abstract class UnityView : MonoBehaviour, IView, IToDestroyListener
{
    protected Contexts contexts;
    protected GameEntity entity;

    protected EntityLink link;

    UnityEntityTemplate _template;

    public string Name { get { return this.gameObject.name; } }

    public void Link (Contexts contexts, GameEntity entity, IEntityTemplate template)
    {
        this.contexts = contexts;
        this.entity = entity;
        this._template = (UnityEntityTemplate)template;

        var link = this.gameObject.GetEntityLink();

        if (link != null && link.entity != null) { this.link = link; }
        else { this.link = this.gameObject.Link(entity, contexts.game); }

        Initialize(contexts, entity);
        RegisterListeners(entity);
        entity.AddToDestroyListener(this);
    }

    public void OnToDestroy (GameEntity entity, uint delay)
    {
        if (delay == 0)
        {
            UnregisterListeners(entity);
            //entity.RemoveToDestroyListener(this);

            link.Unlink();

            if (_template.gameObject.activeSelf)
            {
                UnityEntityService.Instance.Return(_template);
            }
        }
    }

    abstract protected void Initialize (Contexts contexts, GameEntity entity);
    abstract protected void RegisterListeners (GameEntity entity);
    abstract protected void UnregisterListeners (GameEntity entity);
}
