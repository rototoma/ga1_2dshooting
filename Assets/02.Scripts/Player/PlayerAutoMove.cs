using UnityEngine;

[RequireComponent(typeof(PlayerFire))]
public class PlayerAutoMove : MonoBehaviour
{
    private PlayerFire _playerFire;
    private PlayerMove _playerMove;

    [SerializeField] private float _moveLimit;
    [SerializeField] private float _playerSize;

    private GameObject _targetEnemy = null;
    private Vector2 _destination;
    public bool IsAutoMode = false;

    private void Awake()
    {
        _playerFire = GetComponent<PlayerFire>();
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        // 오토 행동 모드 토글
        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsAutoMode = !IsAutoMode;
        }

        if (!IsAutoMode) return;

        if (_targetEnemy != null)
        {
            _playerFire.AutoFireMode = true;
            _playerMove.Move(_destination);
        }
        else
        {
            FindTarget();
        }
    }

    private void GetDestination()
    {
        Vector2 enemyPos = _targetEnemy.transform.position;
        _destination = new Vector2(enemyPos.x, enemyPos.y - _playerSize);
    }

    private void FindTarget()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = 1000f;
        float temp = 0f;
        foreach (var enemy in enemyList)
        {
            temp = (enemy.transform.position - transform.position).magnitude;
            // 너무 가까우면 부딪힐 수 있으니 가지 않는다.
            if (temp < _moveLimit) continue;
            if (temp < minDistance)
            {
                minDistance = temp;
                _targetEnemy = enemy;
            }
        }

        if (_targetEnemy != null)
        {
            GetDestination();
        }
    }
}