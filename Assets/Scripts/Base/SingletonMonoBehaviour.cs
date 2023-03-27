using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                foreach (var t in FindObjectsOfType<T>())
                {
                    if (t != null)
                    {
                        _instance = t;
                        continue;
                    }
                    else
                    {
                        Destroy(t.gameObject);
                    }
                    Destroy(t.gameObject);
                }
            }

            if (_instance == null) _instance = new GameObject($"{typeof(T).ToString()}_SingletonMonoBehaviour").GetComponent<T>();

            return _instance;
        }
    }

    protected virtual void Awake() { }
}