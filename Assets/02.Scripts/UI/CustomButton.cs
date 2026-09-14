using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private Image _buttonImage => targetGraphic as Image;

    [SerializeField] private bool _isInitialOn;

    //todo: 버튼의 종류 (토글, 연속클릭, 애니메이션 적용 등)에 따라 타입별로 사용하기

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _clickSound.Play();

        if (_buttonImage == null)
        {
            Debug.LogError($"Button {name} has no button image");
        }

        if (_onSprite != null)
        {
            _buttonImage.sprite = _isInitialOn ? _offSprite : _onSprite;
            _isInitialOn = !_isInitialOn;
        }
    }
}