using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private Player _playerObj;
    [SerializeField] private ItemSpawnDataTableSO _spawnData;

    public void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void SpawnItem(Vector3 position)
    {
        int itemPrefabIndex = 0;
        int totalWeight = 0;
        foreach (var data in _spawnData.Data)
        {
            totalWeight += data.Weight;
        }

        int radomWeight = UnityEngine.Random.Range(0, totalWeight);

        int cumulativeWeight = 0;
        for (int i = 0; i < _spawnData.Data.Length; i++)
        {
            cumulativeWeight += _spawnData.Data[i].Weight;
            if (radomWeight < cumulativeWeight)
            {
                Item item = ItemPool.Instance.CreateItem(i);

                item.transform.position = position;
                item.PlayerObj = _playerObj;
                return;
            }
        }
    }
}