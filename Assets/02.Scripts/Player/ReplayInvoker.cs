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
    private Queue<Command> _commandQueue = new Queue<Command>();
    
    private void Update()
    {
        if (_commandQueue.Count != 0)
        {
            Command command = _commandQueue.Dequeue();

            if (transform.position.y >= 0 && command.Direction.y >= 0)
            {
                command.Direction.y = 0;
            }

            if (transform.position.y < _yMin && command.Direction.y <= 0)
            {
                command.Direction.y = 0;
            }

            if (transform.position.x < -_xMax && command.Direction.x <= 0)
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
            }

            if (transform.position.x > _xMax && command.Direction.x >= 0)
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
            }


            // 3. 방향과 속도에 따라 이동한다.
            transform.Translate(command.Direction * _initialSpeed * command.DeltaTime);
        }
    }

    public void Replay(Queue<Command> commandQueue, float speed, float yMin, float xMax)
    {
        transform.position = _initialPosition;
        _commandQueue = new Queue<Command>(commandQueue);
        _initialSpeed = speed;
        _yMin = yMin;
        _xMax = xMax;
    }
    
    public void SetInitialPosition(Vector2 initialPosition)
    {
        _initialPosition = initialPosition;
    }
}
