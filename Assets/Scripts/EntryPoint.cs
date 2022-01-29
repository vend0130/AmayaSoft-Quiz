using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Quiz.Bundle;
using Quiz.Data;

namespace Quiz
{
    [RequireComponent(typeof(LevelDataGeneration))]
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CardSpawner _cardSpawner;

        [SerializeField] private CardBundleData[] _cardsBundle;
        [SerializeField] private LevelBundleData _level;

        [SerializeField] private UnityEvent _findCardEvent;
        [SerializeField] private UnityEvent _endGame;

        private LevelDataGeneration _levelsDataGeneration;
        [SerializeField] private List<LevelData> _levelData = new List<LevelData>();

        private int _currentLevel = 0;
        private bool _firstLoad = true;

        private void Start()
        {
            _levelsDataGeneration = GetComponent<LevelDataGeneration>();
            _levelData = _levelsDataGeneration.GenerateLevels(_level.Levels, _cardsBundle);
            Spawn();
            _firstLoad = false;
        }

        public void NextLevel()
        {
            _currentLevel++;
            if(_currentLevel < _levelData.Count)
                Spawn();
            else
                _endGame.Invoke();
        }

        private void Spawn()
        {
            _cardSpawner.Spawn(_level.Levels[_currentLevel], _levelData[_currentLevel], _findCardEvent, _firstLoad);
        }
    }
}