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

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("아이템 충돌");
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        switch (Type)
        {
            case ItemType.Heal:
                {
                    player.Heal((int)Value);
                    break;
                }
            case ItemType.FireRateUp:
                {
                    player.GetComponent<PlayerFire>().FireUp(Value);
                    break;
                }
            case ItemType.MoveSpeedUp:
                {
                    player.GetComponent<PlayerMove>().SpeedUp(Value);
                    break;
                }
        }

        Destroy(gameObject);
    }
}