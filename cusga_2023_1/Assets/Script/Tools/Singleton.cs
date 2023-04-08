using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static T instance;
    
    public static T Instance
    {
        get => instance;
    }
    
    protected virtual void Awake()
    {
        if(instance== null)
        {
            instance = (T)this;
        }
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad((T)this);
    }

    public static bool IsInitialized
    {
        get
        {
            return instance != null;
        }
    }
    
    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance=null;
        }
    }
}
