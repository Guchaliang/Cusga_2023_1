using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab => prefab;

    public int Size => size;

    public int RuntimeSize => queue.Count;
    
    [SerializeField] GameObject prefab;
    [SerializeField] int size;
    Queue<GameObject> queue;

    private Transform parent;
        
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();

        this.parent = parent;
        
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }
    
    GameObject Copy()
    {
       var copy= GameObject.Instantiate(prefab,parent);
       
       copy.SetActive(false);
       
       return copy;
    }

    GameObject AvailableGameObject()
    {
        GameObject availableGameObject = null;
        if (queue.Count > 0&&!queue.Peek().activeSelf)
        {
            availableGameObject = queue.Dequeue();
        }
        else
        {
            availableGameObject = Copy();
        }

        queue.Enqueue(availableGameObject);
        
        return availableGameObject;
    }

    public GameObject PreparedObject()
    {
        GameObject preparedGameObject = AvailableGameObject();
        
        preparedGameObject.SetActive(true);
        
        return preparedGameObject;
    }
    
    public GameObject PreparedObject(Vector2 position)
    {
        GameObject preparedGameObject = AvailableGameObject();
        
        preparedGameObject.SetActive(true);
        preparedGameObject.transform.position = position;
        
        return preparedGameObject;
    }
    
    public GameObject PreparedObject(Vector2 position,Quaternion rotation)
    {
        GameObject preparedGameObject = AvailableGameObject();
        
        preparedGameObject.SetActive(true);
        preparedGameObject.transform.position = position;
        preparedGameObject.transform.rotation = rotation;
        
        return preparedGameObject;
    }
    
    public GameObject PreparedObject(Vector2 position,Quaternion rotation,Vector2 localScale)
    {
        GameObject preparedGameObject = AvailableGameObject();
        
        preparedGameObject.SetActive(true);
        preparedGameObject.transform.position = position;
        preparedGameObject.transform.rotation = rotation;
        preparedGameObject.transform.localScale = localScale;
        
        return preparedGameObject;
    }
} 
