using UnityEngine;

public class EnemyToPlayer : Enemy
{
    public override void Move()
    {
        Vector3 myPos = transform.position;
        Vector2 direction = new Vector2(initialPlayerPos.x - myPos.x, initialPlayerPos.y - myPos.y).normalized;
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}