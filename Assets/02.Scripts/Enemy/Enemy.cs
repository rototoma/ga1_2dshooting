using System;
using UnityEngine;
using UnityEngine.Analytics;

public abstract class Enemy : MonoBehaviour
{
    public Player PlayerObj;
    protected Vector3 initialPlayerPos;
    [SerializeField] private float _health = 400;
    public float Health => _health;
    [SerializeField] protected float moveSpeed = 1f;
    public float MoveSpeed => _health;
    private Animator _animator;

    public Item ItemPrefab;

    public int Damage = 40;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        initialPlayerPos = PlayerObj.transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void Hit(float damage)
    {
        _animator.SetTrigger("Hit");
        _health -= damage;
        if (_health <= 0)
        {
            int itemPrefabIndex = 0;
            int radomPercent = UnityEngine.Random.Range(0, 100);

            // Todo: Scriptable Object를 사용해서 리팩토링
            // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
            // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵
            if (radomPercent < 33)
            {
                itemPrefabIndex = 0;
            }
            else if (radomPercent < 66)
            {
                itemPrefabIndex = 1;
            }
            else
            {
                itemPrefabIndex = 2;
            }

            Item item = Instantiate(ItemPrefab);
            item.transform.position = transform.position;
            item.PlayerObj = PlayerObj;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerObj = other.gameObject.GetComponent<Player>();
        PlayerObj.TakeDamage(Damage);
        Destroy(gameObject);
    }

    public abstract void Move();
}