using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private Image _buttonImage;

    [SerializeField] private bool _isInitialOn;

    //todo: 버튼의 종류 (토글, 연속클릭, 애니메이션 적용 등)에 따라 타입별로 사용하기

    protected override void Awake()
    {
        base.Awake();

        _buttonImage = targetGraphic as Image;
        if (_buttonImage == null)
        {
            Debug.LogError($"{name}: Target Graphic이 Image가 아닙니다.", this);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _clickSound.Play();

        if (_onSprite != null)
        {
            _buttonImage.sprite = _isInitialOn ? _offSprite : _onSprite;
            _isInitialOn = !_isInitialOn;
        }
    }
}