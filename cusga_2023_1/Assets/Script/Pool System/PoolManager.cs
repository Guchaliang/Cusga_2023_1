using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Pool[] bulletPools;
    [SerializeField] private Pool[] EnemyPools;
    [SerializeField] private Pool[] RoomPools;

    private static Dictionary<GameObject, Pool> directory;
    
    private void Start()
    {
        directory = new Dictionary<GameObject, Pool>();
        
        Initialize(bulletPools);
        Initialize(EnemyPools);
        Initialize(RoomPools);
    }



#if UNITY_EDITOR
    private void OnDestroy()
    {
        
    }
#endif
    
    void CheckPoolSize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (pool.RuntimeSize > pool.Size)
            {
                Debug.LogError(String.Format( pool.Prefab.name, pool.RuntimeSize, pool.Size));
            }
        }
    }
    
    void Initialize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
    #if UNITY_EDITOR
            if(directory.ContainsKey(pool.Prefab)){
                Debug.LogError("Same prefab in multiple pools!Prefab:"+pool.Prefab.name);
                continue;
            }
    #endif
            directory.Add(pool.Prefab,pool);
            
            Transform poolParent = new GameObject("Pool:" + pool.Prefab.name).transform;

            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    public static GameObject Release(GameObject prefab,Vector2 position)//释放对应的对象
    {
    #if UNITY_EDITOR
        if (!directory.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not fin prefab:"+prefab.name);
            return null;
        }
    #endif
        
        return directory[prefab].PreparedObject(position);
    }
    
    public static GameObject Release(GameObject prefab,Vector2 position,Quaternion rotation)//释放对应的对象
    {
    #if UNITY_EDITOR
        if (!directory.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not fin prefab:"+prefab.name);
            return null;
        }
    #endif
        
        return directory[prefab].PreparedObject(position,rotation);
    }
    
    public static GameObject Release(GameObject prefab,Vector2 position,Quaternion rotation,Vector2 localScale)//释放对应的对象
    {
    #if UNITY_EDITOR
        if (!directory.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not fin prefab:"+prefab.name);
            return null;
        }
    #endif
        
        return directory[prefab].PreparedObject(position,rotation,localScale);
    }
}
