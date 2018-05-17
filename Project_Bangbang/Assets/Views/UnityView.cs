using UnityEngine;
using System.Collections;
using Entitas.Unity;

public abstract class UnityView : MonoBehaviour, IView, IGameToDestroyListener
{
    protected Contexts contexts;
    protected GameEntity entity;

    protected EntityLink link;

    UnityEntityTemplate _template;

    public Contexts Contexts { get { return contexts; } }

    public int ID { get { return entity.iD.number; } }

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
        entity.AddGameToDestroyListener(this);
    }

    public void OnToDestroy (GameEntity entity, uint delay)
    {
        if (delay == 0)
        {
            UnregisterListeners(entity);
            //entity.RemoveToDestroyListener(this);

            if (link != null && link.entity != null) { link.Unlink(); }

            if (_template.gameObject.activeSelf)
            {
                Contexts.sharedInstance.meta.entityService.current.Return(_template);
            }
        }
    }

    abstract protected void Initialize (Contexts contexts, GameEntity entity);
    abstract protected void RegisterListeners (GameEntity entity);
    abstract protected void UnregisterListeners (GameEntity entity);
}
