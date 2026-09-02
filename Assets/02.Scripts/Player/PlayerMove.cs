using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 필요 필드:
    public float Speed;
    public float yMin;
    public float xMax;
    public float speedMultiplier;
    
    private void Update()
    {
        // 1. 키보드 입력을 받는다.

        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed *= speedMultiplier;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed /= speedMultiplier;
        }
        
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
        // == transform.position = transform.position + (Vector3)direction * Speed * Time.deltaTime;
    }
}
