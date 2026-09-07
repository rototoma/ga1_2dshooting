using System;
using UnityEngine;
using UnityEngine.Analytics;

public abstract class Enemy : MonoBehaviour
{
    public Player PlayerObj;
    protected Vector3 initialPlayerPos;
    [SerializeField] private float _health = 400;
    [SerializeField] protected float MoveSpeed = 1f;

    public int Damage = 40;

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
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public abstract void Move();
}