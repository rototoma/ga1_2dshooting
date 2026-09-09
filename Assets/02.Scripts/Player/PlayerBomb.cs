using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    // - 쿨타이머
    [SerializeField] private float _coolTime = 10f;
    public float CoolTimer = 0f;

    [SerializeField] private GameObject _bombObject;

    private void Start()
    {
        CoolTimer = _coolTime;
    }

    private void Update()
    {
        CoolTimer -= Time.deltaTime;

        if (CoolTimer <= 0 && Input.GetKeyDown(KeyCode.B))
        {
            Fire();
            CoolTimer = _coolTime;
        }
    }

    private void Fire()
    {
        GameObject bomb = Instantiate(_bombObject);
        bomb.transform.position = Vector3.zero;
    }
}