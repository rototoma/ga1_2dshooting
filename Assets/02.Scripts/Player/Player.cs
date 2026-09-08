using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    // getter
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;
    }
}