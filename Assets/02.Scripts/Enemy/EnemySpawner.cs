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
    private int _totalWeight;

    // 생성 위치
    [SerializeField] private GameObject[] _spawnPoints;

    public Player PlayerObj;

    [SerializeField] private EnemyBalanceDataTableSO _enemyBalanceDataTableSo;

    private void Start()
    {
        foreach (var data in _spawnData.Data)
        {
            _totalWeight += data.Weight;
        }
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

        int spawnIdx = UnityEngine.Random.Range(0, _spawnPoints.Length);
        int radomWeight = UnityEngine.Random.Range(0, _totalWeight);

        int cumulativeWeight = 0;
        for (int i = 0; i < _spawnData.Data.Length; i++)
        {
            cumulativeWeight += _spawnData.Data[i].Weight;
            if (radomWeight < cumulativeWeight)
            {
                Enemy enemy = EnemyPool.Instance.CreateEnemy((int)_spawnData.Data[i].Enemy.Type);
                enemy.PlayerObj = PlayerObj;
                enemy.transform.position = _spawnPoints[spawnIdx].transform.position;
                enemy.SetHealthBalance(GetHealthMultiplier());
                return;
            }
        }
    }

    private float GetHealthMultiplier()
    {
        float multiplier = 1.0f;
        int score = ScoreManager.Instance.GetScore();
        foreach (var data in _enemyBalanceDataTableSo.Data)
        {
            if (data.highscore < score)
            {
                multiplier = data.multiplier;
            }
        }

        return multiplier;
    }
}