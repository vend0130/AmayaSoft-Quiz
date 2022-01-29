using UnityEngine;
using System;

namespace Quiz.Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _rotation;

        public string Identifier => _identifier;
        public Sprite Sprite => _sprite;
        public int Rotation => _rotation;
    }
}