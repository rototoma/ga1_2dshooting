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
    public float MoveSpeed => moveSpeed;
    private Animator _animator;

    public Item ItemPrefab;

    public int Damage = 40;

    [SerializeField] private GameObject _deathEffectPrefab;

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
            SpawnDeathEffect();

            Item item = Instantiate(ItemPrefab);
            item.transform.position = transform.position;
            item.PlayerObj = PlayerObj;
            Destroy(gameObject);
        }
    }

    public void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
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