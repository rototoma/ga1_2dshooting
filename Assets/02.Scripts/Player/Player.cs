using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private GameObject _deathEffectPrefab;

    // getter
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            SpawnDeathEffect();
            Destroy(gameObject);
        }
    }

    public void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;
    }
}