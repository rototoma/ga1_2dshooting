using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        //obj.GetComponent<Player>().TakeDamage(Damage);
        TakeDamage(obj.GetComponent<Enemy>().Damage);
        Destroy(obj);
    }
}