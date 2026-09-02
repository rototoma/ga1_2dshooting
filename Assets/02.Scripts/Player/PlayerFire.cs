using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때 마다 총알을 생성해서 발사
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    // - 생성 위치 (총구)
    public Transform FirePoint1;
    public Transform FirePoint2;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet1.transform.position = FirePoint1.position;
            GameObject bullet2 = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet2.transform.position = FirePoint2.position;
        }
        
    }
}
