using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때 마다 총알을 생성해서 발사
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    // - 생성 위치 (총구)
    public Transform FirePoint;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.transform.position = FirePoint.position;
        }
        
    }
}
