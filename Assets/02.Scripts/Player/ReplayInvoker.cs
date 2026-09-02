using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayInvoker : MonoBehaviour
{
    private Vector2 _initialPosition;
    private float _initialSpeed;
    private float _yMin;
    private float _xMax;
    private Queue<(Vector2, float)> _commandQueue = new Queue<(Vector2, float)>();
    
    private void Update()
    {
        if (_commandQueue.Count != 0)
        {
            (Vector2 dir, float time) command = _commandQueue.Dequeue();
            if (transform.position.y >= 0 && command.dir.y>=0)
            {
                command.dir.y = 0;
            }
            if (transform.position.y < _yMin && command.dir.y<=0)
            {
                command.dir.y = 0;
            }
            if (transform.position.x < -_xMax && command.dir.x<=0)
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0); 
            }
            if (transform.position.x > _xMax && command.dir.x>=0)
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0); 
            }

            // 3. 방향과 속도에 따라 이동한다.
            transform.Translate(command.dir * _initialSpeed * command.time);
        }
    }

    public void Replay(Queue<(Vector2, float)> commandQueue, float speed, float yMin, float xMax)
    {
        if (_commandQueue.Count == 0)
        {
            transform.position = new Vector2(_initialPosition.x, _initialPosition.y);
            _commandQueue = new Queue<(Vector2, float)>(commandQueue);
            _initialSpeed = speed;
            _yMin = yMin;
            _xMax = xMax;
        }
    }
    
    public void SetInitialPosition(Vector2 initialPosition)
    {
        _initialPosition = initialPosition;
    }
}
