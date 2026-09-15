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

    private void Start()
    {
        Load();
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = _upgrades[index];

        bool isUpgraded = ScoreManager.Instance.SpendScore(upgrade.Cost);
        if (isUpgraded)
        {
            _upgrades[index].LevelUp();
            RefreshUI();
            Save();
        }
    }

    public void RefreshUI()
    {
        foreach (var uiUpgrade in _uiupgrades)
        {
            uiUpgrade.Refresh();
        }
    }

    private void Save()
    {
        for (int i = 0; i < _upgrades.Length; i++)
        {
            PlayerPrefs.SetInt($"Upgrade.{i}.Level", _upgrades[i].Level);
        }

        PlayerPrefs.Save();
    }

    private void Load()
    {
        int level = 1;
        for (int i = 0; i < _upgrades.Length; i++)
        {
            level = PlayerPrefs.GetInt($"Upgrade.{i}.Level", 1);
            _upgrades[i].SetLevel(level);
        }
    }
}