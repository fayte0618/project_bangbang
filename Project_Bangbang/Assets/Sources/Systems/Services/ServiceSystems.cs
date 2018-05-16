using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ServiceSystems : Feature
{
    public ServiceSystems (Contexts contexts, Services services) : base("Service Systems")
    {
        //Add(system here);
        Add(new EntityServiceInitSystem(contexts, services.entity));
        Add(new InputServiceInitSystem(contexts, services.input));
        Add(new ScreenServiceInitSystem(contexts, services.screen));
        Add(new TimeServiceInitSystem(contexts, services.time));
    }
}