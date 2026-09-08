using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Damage = 1000f;

    public float liveTime;
    public float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > liveTime)
        {
            timer = 0f;
            Destroy(gameObject);
        }
    }

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("꿍");

        // 충돌 대상이 Enemy인 경우
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hit(Damage);
        }
    }
}