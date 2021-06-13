using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolMono<T> where T : MonoBehaviour
{
    public bool isInitialized = false;
    public T prefab { get; }
    public bool isExpandable { get; set; }
    public Transform container { get; }

    private List<T> pool;

    public ObjectPoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        this.CreatePool(count);
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in this.pool)
        {
            if (mono.gameObject.activeInHierarchy == false)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out T element))
            return element;

        if (this.isExpandable)
            return this.CreateObject(true);

        throw new Exception($"There is no elemnts left in {typeof(T)}");
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
        this.isInitialized = true;
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }
}
