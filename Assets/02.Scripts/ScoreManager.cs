using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 접근 가능하다.
    // 2. 인스턴스(생성된 객체)가 하나임을 보장한다.
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;
    private int _bestScore = 0;
    private int _currentScore = 0;

    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private void Awake()
    {
        if (_instance != null) //인스턴스의 유일성 보장
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _bestScoreText.SetText($"Best Score : {_bestScore}");
        _currentScoreText.SetText($"Current Score : {_currentScore}");
    }

    public int GetScore()
    {
        return _bestScore;
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        _currentScoreText.SetText($"Current Score : {_currentScore}");
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            _bestScoreText.SetText($"Best Score : {_bestScore}");
        }
    }
}