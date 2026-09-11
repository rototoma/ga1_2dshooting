using System;
using UnityEngine;
using Random = UnityEngine.Random;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] EnemySpawnDataTableSO _spawnData;
    private float _timer;

    // 생성 위치
    [SerializeField] private GameObject[] _spawnPoints;

    public Player PlayerObj;

    private void Start()
    {
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;

            _spawnInterval = Random.Range(0.3f, 1f); // float: 1 ~ 3

            Spawn();
        }
    }

    private void Spawn()
    {
        // 각 스포너가 적을 스폰할때 확률에 따라 다른 타입의 적을 스폰해주세요.
        // 50%: [0] Downward
        // 30%: [1] Aimed
        // 20%: [2] Homing

        int enemyPrefabIndex = 0;
        int totalWeight = 0;
        foreach (var data in _spawnData.Data)
        {
            totalWeight += data.Weight;
        }

        int radomWeight = UnityEngine.Random.Range(0, totalWeight);


        int cumulativeWeight = 0;
        foreach (var data in _spawnData.Data)
        {
            cumulativeWeight += data.Weight;
            if (radomWeight < cumulativeWeight)
            {
                Enemy enemy = Instantiate(data.Enemy);
                enemy.PlayerObj = PlayerObj.GetComponent<Player>();
                enemy.transform.position = _spawnPoints[UnityEngine.Random.Range(0, 3)].transform.position;
                return;
            }
        }
    }
}