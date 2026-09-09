using System;
using UnityEngine;

public class AwakeTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"AwakeTest{gameObject.name}");
    }

    private void Start()
    {
        Debug.Log($"Start{gameObject.name}");
    }
}