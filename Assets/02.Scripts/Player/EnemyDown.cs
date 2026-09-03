using UnityEngine;

public class EnemyDown : Enemy
{
    public override void Move()
    {
        Vector2 direction = new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}