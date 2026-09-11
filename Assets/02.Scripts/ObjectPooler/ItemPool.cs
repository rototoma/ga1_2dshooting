using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    private static ItemPool _instance;
    public static ItemPool Instance => _instance;

    public Item[,] _pool;
    [SerializeField] private int _poolSize;
    [SerializeField] private ItemSpawnDataTableSO _spawnData;

    private void Awake()
    {
        if (_instance != null) //인스턴스의 유일성 보장
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _pool = new Item[_spawnData.Data.Length, _poolSize];
        for (int i = 0; i < _spawnData.Data.Length; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                Item item = Instantiate(_spawnData.Data[i].Item, gameObject.transform);
                _pool[i, j] = item;
                item.gameObject.SetActive(false);
            }
        }
    }

    public Item CreateItem(int itemType)
    {
        foreach (var item in _pool)
        {
            if ((int)item.Type == itemType && item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        return null;
    }
}