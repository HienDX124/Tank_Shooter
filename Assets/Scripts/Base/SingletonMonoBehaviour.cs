using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            if (this != null)
            {
                _instance = this as T;
            }
            else
            {
                _instance = new GameObject(this.name).GetComponent<T>();
            }
        }
    }
}