using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때 마다 총알을 생성해서 발사
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;
    // - 생성 위치 (총구)
    public Transform FirePointLeft;
    public Transform FirePointRight;
    
    public Transform SubFirePointLeft;
    public Transform SubFirePointRight;

    public float coolDownAmount;
    private float _coolDown;

    public bool toggleAutoAttack = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toggleAutoAttack = !toggleAutoAttack;
        }
        
        if (_coolDown > 0f)
        {
            _coolDown -= Time.deltaTime;
        }
        else if (toggleAutoAttack || Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            FireSubBullet();
        }
    }

    private void Fire()
    {
        GameObject bulletLeft = Instantiate(BulletPrefab, transform.position, transform.rotation);
        bulletLeft.transform.position = FirePointLeft.position;
        GameObject bulletRight = Instantiate(BulletPrefab, transform.position, transform.rotation);
        bulletRight.transform.position = FirePointRight.position;
        _coolDown = coolDownAmount;
    }
    private void FireSubBullet()
    {
        GameObject subBulletLeft = Instantiate(SubBulletPrefab, transform.position, transform.rotation);
        subBulletLeft.transform.position = SubFirePointLeft.position;
        GameObject subBulletRight = Instantiate(SubBulletPrefab, transform.position, transform.rotation);
        subBulletRight.transform.position = SubFirePointRight.position;
        _coolDown = coolDownAmount;
    }
}
