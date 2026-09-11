using System;
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

    public Transform enemyPool;
    private GameObject[] _enemyList;

    private void Awake()
    {
        _playerFire = GetComponent<PlayerFire>();
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        enemyList = new GameObject[enemyPool.childCount];
        for (int i = 0; i < enemyPool.childCount; i++)
        {
            enemyList[i] = enemyPool.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        // 오토 행동 모드 토글
        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsAutoMode = !IsAutoMode;
        }

        if (!IsAutoMode) return;
        if (_targetEnemy == null || _targetEnemy.activeSelf == false)
        {
            FindTarget();
        }
        else
        {
            _playerFire.AutoFireMode = true;
            GetDestination();
            if (((Vector3)_destination - transform.position).magnitude > 0.3f)
            {
                _playerMove.Move(_destination);
            }
        }
    }

    private void GetDestination()
    {
        Vector2 enemyPos = _targetEnemy.transform.position;
        _destination = new Vector2(enemyPos.x, enemyPos.y - _playerSize);
    }

    private void FindTarget()
    {
        float minDistance = 1000f;
        float temp = 0f;
        foreach (var enemy in enemyList)
        {
            if (enemy.activeSelf)
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
        }

        if (_targetEnemy != null)
        {
            GetDestination();
        }
    }
}