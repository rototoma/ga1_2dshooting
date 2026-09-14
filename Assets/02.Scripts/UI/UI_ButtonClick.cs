using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonClick : MonoBehaviour
{
    private Button _button;

    private bool _isOn = false;
    [Header("온오프 스프라이트")]
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private Image _myImage;

    private Animator _animator;

    private AudioSource _audioSource;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _myImage = gameObject.gameObject.GetComponentInChildren<Image>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void OnClickEvent()
    {
        if (_onSprite != null)
        {
            _myImage.sprite = _isOn ? _onSprite : _offSprite;
        }

        _audioSource.Play();
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 0.1f).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f).SetEase(Ease.Linear));
        sequence.Play();
    }
}