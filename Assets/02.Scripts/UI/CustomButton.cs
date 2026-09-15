using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button, IPointerClickHandler
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
        // todo: 기본 사운드 만들어서 clickSound가 null일 경우에는 기본사운드 Play할 수 있도록

        if (_onSprite != null)
        {
            _buttonImage.sprite = _isInitialOn ? _offSprite : _onSprite;
            _isInitialOn = !_isInitialOn;
        }
    }
}