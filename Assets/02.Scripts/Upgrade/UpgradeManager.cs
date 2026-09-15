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

    private const string UpgradeSaveDataKey = "UpgradeSaveData";

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
        UpgradeSaveData saveData = new UpgradeSaveData(_upgrades.Length);
        for (int i = 0; i < _upgrades.Length; i++)
        {
            saveData.Name[i] = _upgrades[i].Name;
            saveData.Level[i] = _upgrades[i].Level;
        }

        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(UpgradeSaveDataKey, json);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(UpgradeSaveDataKey)) return;

        string json = PlayerPrefs.GetString(UpgradeSaveDataKey);
        UpgradeSaveData saveData = JsonUtility.FromJson<UpgradeSaveData>(json);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            _upgrades[i].SetLevel(saveData.Level[i]);
        }
    }
}