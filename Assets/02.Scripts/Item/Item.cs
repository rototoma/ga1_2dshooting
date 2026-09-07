using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player PlayerObj;
    [SerializeField] private float CoolTime;
    public float CoolTimer = 0;
    [SerializeField] protected float MoveSpeed = 1f;

    public virtual void Effect()
    {
    }

    private void Update()
    {
        if (PlayerObj == null)
        {
            Destroy(gameObject);
        }

        Move();
    }

    public void Move()
    {
        Vector3 myPos = transform.position;
        Vector3 playerPos = PlayerObj.transform.position;
        Vector2 direction = new Vector2(playerPos.x - myPos.x, playerPos.y - myPos.y).normalized;
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}