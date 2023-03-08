using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private T prefab;
    private Transform parent;
    private int poolSize;
    private Queue<T> pool;

    public ObjectPool(T prefab, int poolSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.poolSize = poolSize;
        this.parent = parent;

        InitializePool();
    }

    private void InitializePool()
    {
        pool = new Queue<T>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        return null;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
