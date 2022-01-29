using UnityEngine;
using UnityEngine.Events;
using Quiz.Data;

public class Card : MonoBehaviour
{
    [SerializeField] private UnityEvent _effectFindCard;
    [SerializeField] private UnityEvent _fail;
    [SerializeField] private UnityEvent _findCard;
    [SerializeField] private UnityEvent _firsLoad;

    [SerializeField] private SpriteRenderer _cell;
    [SerializeField] private SpriteRenderer _spriteOfElement;

    private string _identifier;
    private bool _target;
    private bool _clickability;

    public bool Clickability { set { _clickability = value; } }

    private void OnMouseDown()
    {
        if (!_clickability)
            return;

        if (_target)
        {
            _clickability = false;
            _effectFindCard.Invoke();
        }
        else
            _fail.Invoke();
    }

    public void SetDataCard(CardData cardData, bool target, Color color, UnityEvent findCardEvent)
    {
        _cell.color = color;
        _spriteOfElement.sprite = cardData.Sprite;
        _identifier = cardData.Identifier;
        _target = target;
        _findCard = findCardEvent;
        transform.Rotate(0, 0, cardData.Rotation);
        _clickability = true;
    }

    public void FirstLoad() => _firsLoad.Invoke();

    public void Find() => _findCard.Invoke();
}