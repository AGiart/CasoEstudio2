using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoState<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static object _syncLock = new object();
    private static MonoState<T> _instance;

    protected virtual void Awake()
    {
        bool destroyMe = true;

        if (_instance == null)
        {
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = this;
                    destroyMe = false;
                }
            }
        }

        if (destroyMe)
        {
            Destroy(gameObject);
        }
    }

    public static T Instance
    {
        get
        {
            return _instance as T;
        }
    }
}
