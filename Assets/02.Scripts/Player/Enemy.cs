using System;
using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{
    public float Health = 400;
    public float MoveSpeed = 0f;

    private void Update()
    {
        Vector2 direction = new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}