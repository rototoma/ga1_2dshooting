using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float Value;
    public Player PlayerObj;
    [SerializeField] protected float MoveSpeed = 4f;
    private const float WaitTime = 2f;
    private float _waitTimer = 0;

    private void Update()
    {
        _waitTimer += Time.deltaTime;
        if (_waitTimer >= WaitTime)
        {
            Move();
        }
    }

    public void Move()
    {
        if (PlayerObj == null)
        {
            Destroy(gameObject);
        }

        Vector3 myPos = transform.position;
        Vector3 playerPos = PlayerObj.transform.position;
        Vector2 direction = new Vector2(playerPos.x - myPos.x, playerPos.y - myPos.y).normalized;
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}