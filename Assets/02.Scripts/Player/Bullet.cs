using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0f;
    public float Damage = 100f;

    private void Update()
    {
        Vector2 direction = new Vector2(0, 1);
        transform.Translate(direction * Speed * Time.deltaTime);
    }
    // 충돌 관련 이벤트 (Enter -> Stay -> Exit)

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("꿍");

        // 충돌 대상이 Enemy인 경우
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.Health <= 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                enemy.Health -= Damage;
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("충돌중이라네 ..");
    }
}