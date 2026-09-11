using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance;
    public static BulletPool Instance => _instance;

    public List<Bullet> _pool = new List<Bullet>();
    [SerializeField] private int _poolSize;
    [SerializeField] private Bullet[] _bulletPrefabs;

    private void Awake()
    {
        if (_instance != null) //인스턴스의 유일성 보장
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        foreach (var bulletPrefab in _bulletPrefabs)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab, gameObject.transform);
                _pool.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
        }
    }

    public Bullet CreateBullet(BulletType bulletType)
    {
        foreach (var bullet in _pool)
        {
            if (bullet._bulletType == bulletType && bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        return null;
    }
}