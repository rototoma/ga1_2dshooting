using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    // - 쿨타이머
    [SerializeField] private float CoolTime = 10f;
    public float CoolTimer = 0f;

    [SerializeField] private GameObject _bombObject;

    private void Start()
    {
        CoolTimer = CoolTime;
    }

    private void Update()
    {
        CoolTimer -= Time.deltaTime;

        if (CoolTimer <= 0 && Input.GetKeyDown(KeyCode.B))
        {
            Fire();
            CoolTimer = CoolTime;
        }
    }

    private void Fire()
    {
        GameObject bomb = Instantiate(_bombObject);
        bomb.transform.position = Vector3.zero;
    }
}