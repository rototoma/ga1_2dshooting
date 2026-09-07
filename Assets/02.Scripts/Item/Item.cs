using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float Value;
    public Player PlayerObj;
    [SerializeField] private float CoolTime;
    public float CoolTimer = 0;
    [SerializeField] protected float MoveSpeed = 1f;

    private void Update()
    {
        Move();
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

            case ItemType.MoveSpeedUp:
                {
                    player.GetComponent<PlayerMove>().SpeedUp(Value);
                    break;
                }

            case ItemType.FireRateUp:
                {
                    player.GetComponent<PlayerFire>().FireUp(Value);
                    break;
                }
        }

        Destroy(gameObject);
    }
}