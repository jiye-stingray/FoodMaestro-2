using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

public class ResourceObjectManager : MonoBehaviour
{
    private Dictionary<string, Object> _dicResource = new Dictionary<string, Object>();

    public GameObject Instantiate(string key, Transform parent = null)
    {
        GameObject tPrefab = Resources.Load<GameObject>($"{key}");
        if (tPrefab == null)
        {
            Debug.LogError($"Error Load {key}");
            return null;
        }

        GameObject tGo = Object.Instantiate(tPrefab, parent);
        tGo.name = tPrefab.name;

        return tGo;
    }


    public T Load<T>(string key) where T : Object
    {
        if (_dicResource.TryGetValue(key, out Object cached))
        {
            return cached as T;
        }

        Object result = null;
        Type t = typeof(T);
        if (t == typeof(Sprite))
        {
            result = Resources.Load<Sprite>(key);
        }
        else if (t == typeof(AudioClip))
        {
            result = Resources.Load<AudioClip>(key);
        }
        else if (t == typeof(Material))
        {
            result = Resources.Load<Material>(key);
        }
        else if(t == typeof(ScriptableObject))
        {
            result = Resources.Load<ScriptableObject>(key);
        }
        else if (t == typeof(GameObject))
        {
            result = Resources.Load<GameObject>(key);
        }
        else
        {
            GameObject go = Resources.Load<GameObject>(key);
            if (go != null)
            {
                result = go.GetComponent<T>();
            }
        }

        if (result != null)
        {
            _dicResource[key] = result;
            return result as T;
        }

        Debug.LogWarning($"Resource not found for key: {key} and type: {typeof(T)}");
        return null;
    }

    public T[] LoadAll<T>(string key) where T : Object
    {
        T[] asset =  Resources.LoadAll<T>(key);
        return asset;
    }

    public void Destroy(GameObject go)
    {
        if (go == null) return;

        DestroyImmediate(go);
    }
}
