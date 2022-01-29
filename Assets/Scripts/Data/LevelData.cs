using System.Collections.Generic;
using UnityEngine;
using System;

namespace Quiz.Data
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private List<CardData> _cardsInLevel;
        [SerializeField] private CardData _targetCard;

        public List<CardData> CardsInLevel => _cardsInLevel;
        public CardData TargetCard => _targetCard;

        public LevelData(CardData targetCard, List<CardData> cardsInLevel)
        {
            _targetCard = targetCard;
            _cardsInLevel = cardsInLevel;
        }
    }
}