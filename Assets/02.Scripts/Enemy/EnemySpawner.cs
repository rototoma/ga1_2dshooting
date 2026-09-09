using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    // 생성 위치
    [SerializeField] private GameObject[] _spawnPoints;

    // - 생성할 프리팹들
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Item[] _itemPrefabs;
    public Player PlayerObj;

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
        int radomPercent = UnityEngine.Random.Range(0, 100);

        // Todo: Scriptable Object를 사용해서 리팩토링
        // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
        // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵
        if (radomPercent < 50)
        {
            enemyPrefabIndex = 0;
        }
        else if (radomPercent < 80)
        {
            enemyPrefabIndex = 1;
        }
        else
        {
            enemyPrefabIndex = 2;
        }

        Enemy enemy = Instantiate(_enemyPrefabs[enemyPrefabIndex]);
        enemy.PlayerObj = PlayerObj.GetComponent<Player>();
        enemy.ItemPrefab = _itemPrefabs[UnityEngine.Random.Range(0, 3)];
        enemy.transform.position = _spawnPoints[UnityEngine.Random.Range(0, 3)].transform.position;
        if (enemyPrefabIndex == 1)
        {
            enemy.transform.rotation =
                Quaternion.Euler(0, 0,
                    180 - Mathf.Atan2(PlayerObj.transform.position.x - enemy.transform.position.x,
                        PlayerObj.transform.position.y - enemy.transform.position.y) * Mathf.Rad2Deg);
        }
    }
}