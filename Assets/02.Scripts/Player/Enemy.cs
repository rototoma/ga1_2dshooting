using System;
using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{
    public PlayerMove playerMove;
    protected Vector3 initialPlayerPos;
    public float Health = 400;
    public float MoveSpeed = 0f;

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
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
    }
}