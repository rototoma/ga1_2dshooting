using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Scriptable Objects/EnemySpawnData")]
public class EnemySpawnDataTableSO : ScriptableObject
{
    public EnemySpawnData[] Data;
}