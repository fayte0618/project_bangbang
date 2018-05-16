using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Stack<T> _pool = new Stack<T>();
    private T _type;

    public ObjectPool (T type)
    {
        _type = type;
        _type.gameObject.SetActive(false);
    }

    public T Get ()
    {

        T obj = null;
        while (_pool.Count != 0)
        {
            obj = _pool.Pop();
            if (obj != null) { break; }
        }

        if (obj == null) { return Instantiate(); }
        else
        {
            obj.gameObject.SetActive(true);
            return obj;
        }

    }

    T Instantiate ()
    {
        var newObj = GameObject.Instantiate(_type);

        newObj.gameObject.SetActive(true);
        return newObj;
    }

    public void Return (T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}

