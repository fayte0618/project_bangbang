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

    [SerializeField]
    private Dictionary<string, ObjectPool<UnityEntityTemplate>> _pool = new Dictionary<string, ObjectPool<UnityEntityTemplate>>();

    //Singleton so that scene objects can access the return to pool function
    private static UnityEntityService _instance = null;
    public static UnityEntityService Instance
    {
        get {
            if (_instance == null) { _instance = GameObject.FindObjectOfType<UnityEntityService>(); }
            return _instance;
        }
    }

    void Awake ()
    {
        var objs = Resources.LoadAll<UnityEntityTemplate>(_baseFolder);
        var sceneObjs = SceneManager.GetActiveScene().GetRootGameObjects()
                        .Select(obj => obj.GetComponentInChildren<UnityEntityTemplate>())
                        .Where(temp => temp != null).ToList();

        sceneObjs.AddRange(objs);

        foreach (var obj in sceneObjs) { AddToPool(obj); }

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
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
        return true; /*_pool[name]?.FirstOrDefault(temp => temp.gameObject.activeSelf == false);*/
    }

    public bool Get (string name, out IEntity entity)
    {
        ObjectPool<UnityEntityTemplate> pool;
        entity = null;

        if (_pool.TryGetValue(name, out pool))
        {
            entity = pool.Get().Create();
            return true;
        }

        return false;
    }

    public void Return (UnityEntityTemplate instance)
    {
        ObjectPool<UnityEntityTemplate> pool;
        if (_pool.TryGetValue(instance.Name, out pool))
        {
            pool.Return(instance);
        }
    }

    void AddToPool (UnityEntityTemplate template)
    {
        ObjectPool<UnityEntityTemplate> pool;
        if (_pool.TryGetValue(template.Name, out pool))
        {
            pool.Return(template);
        }
        else
        {
            pool = new ObjectPool<UnityEntityTemplate>(template);
            _pool.Add(template.Name, pool);
        }
    }

}
