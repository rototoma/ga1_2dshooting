using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0f;
    
    private void Update()
    {
        
        Vector2 direction = new Vector2(0, 1);
        transform.Translate(direction* Speed * Time.deltaTime);
    }
}
