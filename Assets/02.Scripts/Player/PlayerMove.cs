using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 필요 필드:
    public float Speed;
    public float yMin;
    public float xMax;
    public float speedMultiplier;

    public bool replay = false;
    private Queue<Command> _commandQueue = new Queue<Command>();
    
    public ReplayInvoker ReplayInvoker = new ReplayInvoker();

    public void Start()
    {
        ReplayInvoker.SetInitialPosition(transform.position);    
    }
    
    private void Update()
    {
        if (replay) return;
        
        // 1. 키보드 입력을 받는다.
        SpeedChange();

        Move();
        
        // == transform.position = transform.position + (Vector3)direction * Speed * Time.deltaTime;

        if (replay)
        {
            ReplayInvoker.Replay(_commandQueue, Speed, yMin, xMax);
        }
    }

    private void SpeedChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed *= speedMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed /= speedMultiplier;
        }
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");  // 키보드 왼.오른쪽 입력 상태에 따라 -1f~0~1f
        float v = Input.GetAxis("Vertical");    // 키보드 위.아래 입력 상태에 따라 -1f~0~1f
        
        Vector2 direction = new Vector2(h, v);
        if (transform.position.y >= 0 && direction.y>=0)
        {
            direction.y = 0;
        }
        if (transform.position.y < yMin && direction.y<=0)
        {
            direction.y = 0;
        }
        if (transform.position.x < -xMax && direction.x<=0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0); 
        }
        if (transform.position.x > xMax && direction.x>=0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0); 
        }
        
        
        // 3. 방향과 속도에 따라 이동한다.
        transform.Translate(direction * Speed * Time.deltaTime);
        _commandQueue.Enqueue(new Command(direction, Time.deltaTime));
    }
}
