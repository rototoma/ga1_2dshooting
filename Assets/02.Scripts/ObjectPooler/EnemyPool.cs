using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private static EnemyPool _instance;
    public static EnemyPool Instance => _instance;

    public Enemy[,] _pool;
    [SerializeField] private int _poolSize;
    [SerializeField] private EnemySpawnDataTableSO _spawnData;

    private void Awake()
    {
        if (_instance != null) //인스턴스의 유일성 보장
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _pool = new Enemy[_spawnData.Data.Length, _poolSize];
        for (int i = 0; i < _spawnData.Data.Length; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                Enemy enemy = Instantiate(_spawnData.Data[i].Enemy, gameObject.transform);
                _pool[i, j] = enemy;
                enemy.gameObject.SetActive(false);
            }
        }
    }

    public Enemy CreateEnemy(int enemyType)
    {
        foreach (var enemy in _pool)
        {
            if ((int)enemy.Type == enemyType && enemy.gameObject.activeSelf == false)
            {
                enemy.gameObject.SetActive(true);
                return enemy;
            }
        }

        return null;
    }
}