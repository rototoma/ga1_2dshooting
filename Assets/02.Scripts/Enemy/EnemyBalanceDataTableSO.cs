using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBalanceData", menuName = "Scriptable Objects/EnemyBalanceData")]
public class EnemyBalanceDataTableSO : ScriptableObject
{
    public EnemyBalanceData[] Data;
}