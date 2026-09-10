using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 필요 필드:
    private Animator _animator;
    [SerializeField] private float _speed;
    public float Speed => _speed;

    public float yMin;
    public float xMax;
    public float speedMultiplier;

    public bool replay = false;
    private Queue<(Vector2, float)> _commandQueue = new Queue<(Vector2, float)>();

    public ReplayInvoker ReplayInvoker = new ReplayInvoker();

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        ReplayInvoker.SetInitialPosition(transform.position);
    }

    private void Update()
    {
        if (replay)
        {
            ReplayInvoker.Replay(_commandQueue, _speed, yMin, xMax);
            replay = false;
            _commandQueue.Clear();
        }
        else
        {
            SpeedChange();
            Move();
        }

        // == transform.position = transform.position + (Vector3)direction * Speed * Time.deltaTime;
    }

    private void SpeedChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _speed *= speedMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _speed /= speedMultiplier;
        }
    }

    public void SpeedUp(float upValue)
    {
        _speed += upValue;
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal"); // 키보드 왼.오른쪽 입력 상태에 따라 -1f~0~1f
        float v = Input.GetAxis("Vertical"); // 키보드 위.아래 입력 상태에 따라 -1f~0~1f

        Vector2 direction = new Vector2(h, v);
        if (transform.position.y >= 0 && direction.y >= 0)
        {
            direction.y = 0;
        }

        if (transform.position.y < yMin && direction.y <= 0)
        {
            direction.y = 0;
        }

        if (transform.position.x < -xMax && direction.x <= 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        if (transform.position.x > xMax && direction.x >= 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        int forX = h > 0 ? 1 : 0;
        if (h < 0)
        {
            forX = -1;
        }

        _animator.SetInteger("x", (int)forX);

        // 3. 방향과 속도에 따라 이동한다.
        transform.Translate(direction * _speed * Time.deltaTime);
        _commandQueue.Enqueue((direction, Time.deltaTime));
    }

    public void Move(Vector2 destination)
    {
        Vector3 myPos = transform.position;
        if (destination.y >= myPos.y)
        {
            destination.y = myPos.y;
        }

        Vector2 direction = new Vector2(destination.x - myPos.x, destination.y - myPos.y).normalized;
        if (transform.position.y < yMin)
        {
            direction.y = yMin + 0.1f;
        }

        if (transform.position.x < -xMax && direction.x <= 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        if (transform.position.x > xMax && direction.x >= 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        int forX = direction.x > 0 ? 1 : 0;
        if (direction.x < 0)
        {
            forX = -1;
        }

        _animator.SetInteger("x", (int)forX);

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}