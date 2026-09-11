using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    public float Speed = 0f;
    public float Damage = 100f;
    private AudioSource _audioSource;
    public BulletType _bulletType;

    public void OnSpawn()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        _audioSource.Play();
    }

    private void Update()
    {
        Vector2 direction = new Vector2(0, 1);
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("꿍");

        // 충돌 대상이 Enemy인 경우
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hit(Damage);
        }

        gameObject.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("충돌중이라네 ..");
    }
}