using UnityEngine;
using Quiz.Data;

namespace Quiz.Bundle
{
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 0)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] CardData[] _cardData;

        public CardData[] CardData => _cardData;
    }
}