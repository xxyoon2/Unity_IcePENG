using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_Instance.gameObject);
            }

            return _Instance;
        }
    }

    protected void Awake()
    {
        if (_Instance != null)
        {
            if (_Instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }
        _Instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);

    }
}