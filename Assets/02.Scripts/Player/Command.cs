using UnityEngine;

public class Command
{
    public Vector2 Direction;
    public float DeltaTime;
    
    public Command(Vector2 direction, float deltaTime)
    {
        Direction = direction;
        DeltaTime = deltaTime;
    }
}
