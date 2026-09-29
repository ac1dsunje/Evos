using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.World.Pool
{
public class ObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly Transform _container;
    private readonly Stack<T> _pool = new();

    public ObjectPool(T prefab, int prewarmCount = 0, Transform container = null)
    {
        _prefab = prefab;
        _container = container;

        for (var i = 0; i < prewarmCount; i++)
        {
            var instance = Object.Instantiate(_prefab, _container);
            instance.gameObject.SetActive(false);
            _pool.Push(instance);
        }
    }

    public T Get()
    {
        T instance;
        if (_pool.Count > 0)
        {
            instance = _pool.Pop();
        }
        else
        {
            instance = Object.Instantiate(_prefab, _container);
        }
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void Release(T instance)
    {
        instance.gameObject.SetActive(false);
        _pool.Push(instance);
    }
}
}
