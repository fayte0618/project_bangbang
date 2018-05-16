using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class UnityEntityService : MonoBehaviour, IEntityService
{
    [SerializeField]
    private string _baseFolder;

    private bool _isInit = false;

    [SerializeField]
    private Dictionary<string, ObjectPool<UnityEntityTemplate>> _masterPool = new Dictionary<string, ObjectPool<UnityEntityTemplate>>();

    //Singleton so that scene objects can access the return to pool function
    private static UnityEntityService _instance = null;
    public static UnityEntityService Instance
    {
        get {
            if (_instance == null) { _instance = GameObject.FindObjectOfType<UnityEntityService>(); }
            return _instance;
        }
    }

    public void Initialize ()
    {
        if (_isInit) { return; }

        var objs = Resources.LoadAll<UnityEntityTemplate>(_baseFolder);
        var sceneObjs = SceneManager.GetActiveScene().GetRootGameObjects()
                        .Select(obj => obj.GetComponentInChildren<UnityEntityTemplate>())
                        .Where(temp => temp != null).ToList();

        sceneObjs.AddRange(objs);

        foreach (var obj in sceneObjs) { AddToPool(obj); }

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

        _isInit = true;
    }

    private void SceneManager_activeSceneChanged (Scene arg0, Scene arg1)
    {
        var sceneObjs = SceneManager.GetActiveScene().GetRootGameObjects()
                        .Select(obj => obj.GetComponentInChildren<UnityEntityTemplate>())
                        .Where(temp => temp != null);

        foreach (var obj in sceneObjs) { AddToPool(obj); }
    }

    public bool Get (string name)
    {
        IEntity entity;
        Get(name, out entity);
        return true;
    }

    public bool Get (string name, out IEntity entity)
    {
        ObjectPool<UnityEntityTemplate> pool;
        entity = null;

        if (_masterPool.TryGetValue(name, out pool))
        {
            entity = pool.Get().Create();
            return true;
        }

        return false;
    }

    public void Return (UnityEntityTemplate instance)
    {
        AddToPool(instance);
    }

    void AddToPool (UnityEntityTemplate template)
    {
        ObjectPool<UnityEntityTemplate> pool;
        if (_masterPool.TryGetValue(template.Name, out pool))
        {
            pool.Return(template);
        }
        else
        {
            pool = new ObjectPool<UnityEntityTemplate>(template);
            _masterPool.Add(template.Name, pool);
        }
    }

}
