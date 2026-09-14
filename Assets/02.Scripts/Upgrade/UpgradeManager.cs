using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UpgradeManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 접근 가능하다.
    // 2. 인스턴스(생성된 객체)가 하나임을 보장한다.
    private static UpgradeManager _instance;
    public static UpgradeManager Instance => _instance;

    public Upgrade[] _upgrades;
    [SerializeField] UI_Upgrade[] _uiupgrades;

    private void Awake()
    {
        if (_instance != null) //인스턴스의 유일성 보장
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        foreach (var upgrade in _upgrades)
        {
            upgrade.Calculate();
        }

        RefreshUI();
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = _upgrades[index];
        if (ScoreManager.Instance.Score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.SpendScore(upgrade.Cost);
        _upgrades[index].LevelUp();
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (var uiUpgrade in _uiupgrades)
        {
            uiUpgrade.Refresh();
        }
    }
}