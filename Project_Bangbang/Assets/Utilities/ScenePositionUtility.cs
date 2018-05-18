using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;

public class ScenePositionUtility : MonoBehaviour
{
    [SerializeField]
    private StringTransformDictionary _parentList;

    [SerializeField]
    private StringTransformDictionary _spawnPositionList;

    private static ScenePositionUtility _instance;

    public static ScenePositionUtility Instance
    {
        get {
            _instance = _instance ?? GameObject.FindObjectOfType<ScenePositionUtility>();
            return _instance;
        }
    }

    public Transform GetParent (string id)
    {
        Transform parent = null;
        _parentList.TryGetValue(id, out parent);
        return parent;
    }

    public Vector3 GetSpawnPosition (string[] ids)
    {
        var positions = ids.Select(id => GetSpawnPosition(id)).ToArray();

        if (positions.Length == 1) { return positions[0]; }

        return positions[Random.Range(0, positions.Length)];
    }

    public Vector3 GetSpawnPosition (string id)
    {
        Transform trans;
        _spawnPositionList.TryGetValue(id, out trans);

        if (trans is RectTransform)
        {
            return trans == null ? Vector2.zero : ((RectTransform)trans).anchoredPosition;
        }
        return trans == null ? Vector3.zero : trans.position;
    }
}
