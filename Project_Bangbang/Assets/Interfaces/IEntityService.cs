using System;
using Entitas;

public interface IEntityService
{
    bool Get (string name);
    bool Get (string name, out IEntity entity);
    void Return (dynamic entity);
}

