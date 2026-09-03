using System;
using UnityEngine;
using UnityEngine.Analytics;

public abstract class Enemy : MonoBehaviour
{
    public PlayerMove playerMove;
    protected Vector3 initialPlayerPos;
    [SerializeField] private float _health = 400;
    [SerializeField] protected float MoveSpeed = 1f;

    private void Start()
    {
        initialPlayerPos = playerMove.transform.position;
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