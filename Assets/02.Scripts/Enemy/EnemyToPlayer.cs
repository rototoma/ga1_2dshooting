using Unity.Mathematics;
using UnityEngine;

public class EnemyToPlayer : Enemy
{
    public override void Move()
    {
        Vector3 myPos = transform.position;
        Vector2 direction = new Vector2(initialPlayerPos.x - myPos.x, initialPlayerPos.y - myPos.y).normalized;
        transform.rotation =
            Quaternion.Euler(0, 0, 180 - Mathf.Atan2(initialPlayerPos.x, initialPlayerPos.y - 6) * Mathf.Rad2Deg);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}