using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MainController : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _systems;

    private void Awake ()
    {
        _contexts = Contexts.sharedInstance;
        var services = InitServices();
        _systems = CreateSystems(_contexts, services);
        _systems.Initialize();
    }

    private void Update ()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy ()
    {
        _systems.TearDown();
    }

    private Systems CreateSystems (Contexts contexts, Services services)
    {
        return new Feature("Overall Systems")
            .Add(new ServiceSystems(contexts, services))
            .Add(new CreateEntityInputSystem(contexts))
            .Add(new GameEventSystems(contexts))
            .Add(new DestroySystem(contexts));
    }

    private Services InitServices ()
    {
        var entityService = GetComponentInChildren<UnityEntityService>();
        entityService.Initialize();

        return new Services()
        {
            entity = entityService
        };
    }
}
