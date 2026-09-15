using UnityEngine;

[System.Serializable]
public class Upgrade
{
    // 기획자가 채우는 속성
    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] private float _defaultValue;
    [SerializeField] private float _increaseValue;
    [SerializeField] private float _defaultCost;
    [SerializeField] private float _increaseCost;

    // 실행중에 동적으로 바뀌 속성
    private int _level;
    public int Level => _level;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    private float _nextValue;
    public float NextValue => _nextValue;
    private int _cost;
    public int Cost => _cost;

    public void SetLevel(int level)
    {
        _level = level;
        Calculate();
    }

    public void LevelUp()
    {
        _level += 1;

        Calculate();
    }

    public void Calculate()
    {
        _currentValue = _defaultValue + _level * _increaseValue;
        _nextValue = _defaultValue + (_level + 1) * _increaseValue;
        _cost = (int)(_defaultCost + _level * _increaseCost);
    }
}