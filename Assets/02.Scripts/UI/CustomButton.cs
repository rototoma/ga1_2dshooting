using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Image _buttonImage;

    [SerializeField] private bool _initialState;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _clickSound.Play();
        if (_onSprite != null)
        {
            if (_initialState)
            {
                _buttonImage.sprite = _onSprite;
            }
            else
            {
                _buttonImage.sprite = _offSprite;
            }
        }
    }
}