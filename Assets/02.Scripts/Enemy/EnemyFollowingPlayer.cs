using UnityEngine;

public class EnemyFollowingPlayer : Enemy
{
    public override void Move()
    {
        Vector3 myPos = transform.position;
        Vector3 playerPos = PlayerObj.transform.position;
        Vector2 direction = new Vector2(playerPos.x - myPos.x, playerPos.y - myPos.y).normalized;
        transform.rotation =
            Quaternion.Euler(0, 0, 180 - Mathf.Atan2(playerPos.x - myPos.x, playerPos.y - myPos.y) * Mathf.Rad2Deg);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}