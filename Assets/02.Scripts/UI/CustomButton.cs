using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Image _buttonImage;

    [SerializeField] private bool _isInitialOn;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _clickSound.Play();
        if (_onSprite != null)
        {
            if (_isInitialOn)
            {
                targetGraphic.GetComponent<Image>().sprite = _offSprite;
                _isInitialOn = !_isInitialOn;
            }
            else
            {
                targetGraphic.GetComponent<Image>().sprite = _onSprite;
                _isInitialOn = !_isInitialOn;
            }
        }
    }
}