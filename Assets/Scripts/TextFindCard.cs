using UnityEngine;
using UnityEngine.UI;

public class TextFindCard : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void UpdateText(CardSpawner cardSpawner)
    {
        _text.text = $"Find {cardSpawner.TargetCard}";
    }
}