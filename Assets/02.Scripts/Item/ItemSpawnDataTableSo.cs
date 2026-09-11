using UnityEngine;

[CreateAssetMenu(fileName = "ItemSpawnData", menuName = "Scriptable Objects/ItemSpawnData")]
public class ItemSpawnDataTableSO : ScriptableObject
{
    public ItemSpawnData[] Data;
}