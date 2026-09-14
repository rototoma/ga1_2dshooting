using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_AutoBtn : MonoBehaviour
{
    private bool _isAutoMode = false;
    private Player _player;

    private bool _isBumping = false;
    private float _elapsedTime = 0f;

    private void Start()
    {
        _player = GameObject.FindAnyObjectByType<Player>();
    }

    public void AutoToggle()
    {
        _player.GetComponent<PlayerAutoMove>().SetAutoMode();
        _isAutoMode = !_isAutoMode;
    }
    // todo : 버튼 클릭할 때 애니메이션 + 사운드 추가하기
}