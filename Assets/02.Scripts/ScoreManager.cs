using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _bestScore = 0;
    private int _currentScore = 0;

    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

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

    private void Start()
    {
        _bestScoreText.SetText($"Best Score : {_bestScore}");
        _currentScoreText.SetText($"Current Score : {_currentScore}");
    }
}