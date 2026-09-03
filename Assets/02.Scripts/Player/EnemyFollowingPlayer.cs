using UnityEngine;

public class EnemyFollowingPlayer : Enemy
{
    public override void Move()
    {
        Vector3 myPos = transform.position;
        Vector3 playerPos = playerMove.transform.position;
        Vector2 direction = new Vector2(playerPos.x - myPos.x, playerPos.y - myPos.y).normalized;
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}