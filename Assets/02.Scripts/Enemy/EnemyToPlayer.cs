using UnityEngine;

public class EnemyToPlayer : Enemy
{
    private Vector2 _direction;

    private void Start()
    {
        initialPlayerPos = PlayerObj.transform.position;
        _direction = initialPlayerPos - transform.position;

        float dx = _direction.x; // 플레이어와 에너미 사이의 밑변 길이
        float dy = _direction.y; // 플레이어와 에너미 사이의 높이 길이
        // tan세타 = dy / dx
        // tan^ * tan세타 = tan^ * dy / dx
        // 세타 = tant^ * dy / dx
        // 각도 = 세타 * Rad2Deg
        float radian = Mathf.Atan2(dy, dx);
        float angle = radian * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        _direction.Normalize();
    }

    public override void Move()
    {
        Vector3 myPos = transform.position;
        // transform.Translate(direction * MoveSpeed * Time.deltaTime);
        transform.position += (Vector3)(_direction * MoveSpeed) * Time.deltaTime;
    }
}